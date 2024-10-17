using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform enemyTarget;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {        
        SetEnemyRange();
    }

    void SetEnemyRange()
    {
        distanceToTarget = Vector3.Distance(enemyTarget.position, transform.position);

        if (distanceToTarget <= chaseRange)
        {
            FaceTarget();
            ChaseTarget();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    void ChaseTarget()
    {
        agent.SetDestination(enemyTarget.position);
    }

    void FaceTarget()
    {
        Vector3 faceDirection = (enemyTarget.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(faceDirection.x, 0, faceDirection.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
