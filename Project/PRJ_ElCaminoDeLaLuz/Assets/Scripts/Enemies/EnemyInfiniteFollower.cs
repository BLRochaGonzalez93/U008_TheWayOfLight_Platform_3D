using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInfiniteFollower : MonoBehaviour
{
    [SerializeField] private Animator animController;
    [SerializeField] private float inputMagnitud;

    [Header("Patrol")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<Transform> patrolPoints;
    private int currentPoint;

    [Header("Follow")]
    [SerializeField] private float minDistanceToFollow;     //Distancia minima de Detección
    [SerializeField] private Transform target;              //Target

    [Header("Alert")]
    [SerializeField] private FollowEnemyStates state;
    [SerializeField] private float distanceToAttack;
    [SerializeField] private GameObject mouth;

    private void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        switch (state)
        {
            case FollowEnemyStates.Patrol:
                PatrolUpdate();
                break;
            case FollowEnemyStates.Follow:
                FollowUpdate();
                break;
            case FollowEnemyStates.Attack:
                AttackUpdate();
                break;
        }
    }

    void PatrolUpdate()
    {
        agent.speed = 10;
        mouth.GetComponent<CapsuleCollider>().enabled = false;
        animController.SetFloat("OnMove", 0, 0.2f, Time.deltaTime);
        agent.SetDestination(patrolPoints[currentPoint].position);
        if (agent.remainingDistance < 1f)
        {
            currentPoint = Random.Range(0, patrolPoints.Count);
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
        TargetDetect();
    }
    void FollowUpdate()
    {
        if (target != null)
        {
            TargetDetect();
            mouth.GetComponent<CapsuleCollider>().enabled = false;
            agent.isStopped = false;
            agent.SetDestination(target.position);
            agent.speed = 17;
            animController.SetFloat("OnMove", 1, 0.2f, Time.deltaTime);

            if (Vector3.Distance(transform.position, target.position) <= distanceToAttack)
            {
                state = FollowEnemyStates.Attack;
            }
        }
    }

    void AttackUpdate()
    {
        if (Vector3.Distance(transform.position, target.position) > distanceToAttack)
        {
            state = FollowEnemyStates.Follow;
        }
        else
        {
            agent.speed = 0;
            StartCoroutine("Attack");
        }
        TargetDetect();
    }

    void TargetDetect()
    {
        Collider[] allDetects = Physics.OverlapSphere(transform.position, minDistanceToFollow);
        for (int i = 0; i < allDetects.Length; i++)
        {
            if (allDetects[i].CompareTag("Player"))
            {
                target = allDetects[i].transform;
                if (Vector3.Distance(transform.position, target.position) <= distanceToAttack)
                {
                    state = FollowEnemyStates.Attack;
                }
                else
                {
                    state = FollowEnemyStates.Follow;
                }
                return;
            }
           
        }
    }

    private IEnumerator Attack()
    {
        agent.isStopped = true;
        agent.speed = 0;
        animController.Play("Atacar");
        yield return new WaitForSeconds(1f);
        agent.isStopped = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpecialAttack"))
        {
            gameObject.GetComponent<DestroyObjects>().GetHits();
        }
    }
}
