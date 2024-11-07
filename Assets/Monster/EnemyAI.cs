using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform enemyTarget;
    [SerializeField] Transform[] patrolPoints;
    [SerializeField] DamageUI damagedOverlay;
    [SerializeField] AudioClip chaseSound;
    [SerializeField] AudioClip attackSFX;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float patrolSpotThreshhold = 1f;
    
    NavMeshAgent agent;
    FlashlightBehavior flashlightBehavior;
    AudioSource audioSource;
    float distanceToTarget = Mathf.Infinity;    
    bool isProvoked = false;
    public bool isPlayingMusic = false;
    int currentPatrolIndex = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        flashlightBehavior = FindAnyObjectByType<FlashlightBehavior>();        
        GoToNextPoint();
    }
    
    void Update()
    {
        SetEnemyBehavior();
    }

    void SetEnemyBehavior()
    {
        distanceToTarget = Vector3.Distance(enemyTarget.position, transform.position);

        if (distanceToTarget <= chaseRange && distanceToTarget > (agent.stoppingDistance))
        {
            isProvoked = true;
            isPlayingMusic = true;
            flashlightBehavior.FlickerPlayerLights();
            ChaseTarget();
        }
        else if (distanceToTarget > chaseRange)
        {
            isProvoked = false;
            isPlayingMusic = false;            
            PatrolArea();
        }
        else if (distanceToTarget <= (agent.stoppingDistance))
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        if (isProvoked)
        {
            FaceTarget();
            GetComponent<Animator>().SetBool("isIdle", false);
            GetComponent<Animator>().SetBool("isAttacking", false);
            GetComponent<Animator>().SetTrigger("isChasing");
            agent.SetDestination(enemyTarget.position);
            agent.speed = 4f;
            PlayChaseMusic();
        }        
    }

    void PlayChaseMusic()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = chaseSound;
            audioSource.Play();            
        }
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        PlayAttackSFX();     
        damagedOverlay.ShowDamageUI();
    }

    void PlayAttackSFX()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = attackSFX;
            audioSource.Play();            
        }
        else if (audioSource.clip == chaseSound)
        {
            audioSource.Stop();
            audioSource.clip = attackSFX;
            audioSource.Play();            
        }
    }

    void OnDrawGizmosSelected()
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
        flashlightBehavior.GetComponent<Light>().intensity = 1.5f; //Resets player flashlight intensity.
        GetComponent<Animator>().SetBool("isIdle", true);
        agent.speed = 2.5f;
        audioSource.Stop();

        if (!agent.pathPending && agent.remainingDistance <= patrolSpotThreshhold) //Make sure threshhold matches agent stopping distance or it wont work.
        {            
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
