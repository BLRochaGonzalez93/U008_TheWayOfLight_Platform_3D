using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum FollowEnemyStates { Patrol, Follow, Attack }

public class EnemyFollowerControl : MonoBehaviour
{
    [SerializeField] private Animator animController;
    [SerializeField] private float inputMagnitud;

    [Header("Patrol")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<Transform> patrolPoints;
    private int currentPoint;

    [Header("Follow")]
    [SerializeField] private Transform center;              //Centro del radio de seguimiento
    [SerializeField] private float maxDistanceFromCenter;   //Distancia maxima de seguimiento
    [SerializeField] private float minDistanceToFollow;     //Distancia minima de Detección
    [SerializeField] private Transform target;              //Target

    [Header("Alert")]
    [SerializeField] private FollowEnemyStates state;
    [SerializeField] private float distanceToAttack;
    [SerializeField] private GameObject dagger;

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
        agent.speed = 8;
        dagger.GetComponent<CapsuleCollider>().enabled = false;
        animController.SetFloat("OnMove", 0, 0.2f, Time.deltaTime);
        agent.SetDestination(patrolPoints[currentPoint].position);
        if (agent.remainingDistance < 1f)
        {
            inputMagnitud = Mathf.Clamp01(new Vector3(transform.position.x, 0, transform.position.y).magnitude);
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
            dagger.GetComponent<CapsuleCollider>().enabled = false;
            agent.isStopped = false;
            agent.SetDestination(target.position);
            agent.speed = 12;
            animController.SetFloat("OnMove", 1, 0.2f, Time.deltaTime);
            if (Vector3.Distance(center.position, transform.position) > maxDistanceFromCenter)
            {
                target = null;
                //agent.isStopped = true;
                //timerAlert = 0;
                //state = FollowEnemyStates.LookingFor;
                state = FollowEnemyStates.Patrol;
            }

            if (target != null && Vector3.Distance(transform.position, target.position) <= distanceToAttack)
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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collider: " + collision);
        if (collision.gameObject.CompareTag("SpecialAttack"))
        {
            Debug.Log("Alcanzado");
            gameObject.GetComponent<DestroyObjects>().GetHits();
        }
    }
}
