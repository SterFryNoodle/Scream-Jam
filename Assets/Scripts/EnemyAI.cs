using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform enemyTarget;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float patrolSpotThreshhold = 1f;

    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;    
    bool isProvoked = false;
    int currentPatrolIndex = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToNextPoint();
    }
    
    void Update()
    {
        SetEnemyBehavior();
    }

    private void SetEnemyBehavior()
    {
        distanceToTarget = Vector3.Distance(enemyTarget.position, transform.position);

        if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
            ChaseTarget();
        }
        else
        {
            isProvoked = false;
            PatrolArea();
        }
    }

    void ChaseTarget()
    {
        if (isProvoked)
        {
            FaceTarget();
            GetComponent<Animator>().SetTrigger("isChasing");
            GetComponent<Animator>().SetBool("isIdle", false);
            agent.SetDestination(enemyTarget.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }    

    void FaceTarget()
    {
        Vector3 faceDirection = (enemyTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(faceDirection.x, 0, faceDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void PatrolArea()
    {        
        if (!agent.pathPending && agent.remainingDistance <= patrolSpotThreshhold)
        {
            GetComponent<Animator>().SetBool("isIdle", true);
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        if (patrolPoints.Length == 0)
        {
            return;
        }

        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }
}
