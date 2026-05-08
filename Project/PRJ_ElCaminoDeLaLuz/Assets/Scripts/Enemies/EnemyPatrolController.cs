using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrolController : MonoBehaviour
{
    [Header("Patrol")]
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private List<Transform> patrolPoints;
    private int currentPoint;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(patrolPoints[currentPoint].position);
        if (agent.remainingDistance < 0.5f)
        {
            currentPoint++;
            if (currentPoint >= patrolPoints.Count)
            {
                currentPoint = 0;
            }
            agent.SetDestination(patrolPoints[currentPoint].position);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpecialAttack"))
        {
            gameObject.GetComponent<DestroyObjects>().GetHits();
        }
    }
}
