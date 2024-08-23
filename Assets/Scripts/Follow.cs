using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow : MonoBehaviour
{
    [SerializeField] Transform targetObj;
    [SerializeField] float attackRange = 3f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, targetObj.position);

        if (distanceToPlayer <= attackRange)
        {
            agent.isStopped = true;
            Debug.Log("Attacking!");
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(targetObj.position);
        }
    }
}
