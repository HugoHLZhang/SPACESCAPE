using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiesController : MonoBehaviour
{
    private NavMeshAgent agent = null;
    private Transform target;
    private Animator anim = null;
    private float attackTimer;
    private bool hasStopped = false;

    private AlienStats stats = null;

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
        

        float distanceBetweenPlayer = Vector3.Distance(target.position, transform.position) - 0.3f;
        if (distanceBetweenPlayer <= agent.stoppingDistance)
        {
            anim.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);
            RotateToTarget();
            //Attack
            CharacterStats targetStats = target.GetComponent<CharacterStats>();
            if (!hasStopped)
            {
                hasStopped = true;
                attackTimer = Time.time;
                StartCoroutine(AttackTarget(targetStats));
            }
            
            if(Time.time >= attackTimer + stats.attackSpeed)
            {
                attackTimer = Time.time;
                StartCoroutine(AttackTarget(targetStats));
            }
        }
        else
        {
            anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
            if (hasStopped)
            {
                hasStopped = true;
            }
        }
    }

    private IEnumerator AttackTarget(CharacterStats statsToDamage)
    {
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(1f);
        anim.SetFloat("Speed", 0f, 0.3f, Time.deltaTime);
        float distanceBetweenPlayer = Vector3.Distance(target.position, transform.position) - 0.3f;
        if (distanceBetweenPlayer <= agent.stoppingDistance)
        {
            stats.DealDamage(statsToDamage);
        }
    }
    private void RotateToTarget()
    {
        //transform.LookAt(target);
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;
    }

    private void GetReference()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<AlienStats>();
        target = PlayerController.instance.transform;
    }
}
