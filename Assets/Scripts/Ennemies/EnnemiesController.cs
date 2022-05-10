using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiesController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    [SerializeField] private Transform target;
    private void Start()
    {
        GetReference();
    }
    private void Update()
    {
        moveToTarget();
    }

    private void moveToTarget()
    {
        agent.SetDestination(target.position);
    }

    private void GetReference()
    {
        agent = GetComponent<NavMeshAgent>();
    }
}
