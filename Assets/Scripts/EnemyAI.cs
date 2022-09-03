using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private NavMeshAgent enemyNavMesh;
    [SerializeField] private float chaseRange = 5f;
    [SerializeField] private float turnSpeed = 5f;




    private EnemyHealth health;
    private float distanceToTarget = Mathf.Infinity;
    private bool isProvoked = false;

    private void Awake()
    {
        health = GetComponent<EnemyHealth>();
        enemyNavMesh = GetComponent<NavMeshAgent>();
        Debug.Log(distanceToTarget);
    }


    void Update()
    {
        if (health.IsDead())
        {
            enemyNavMesh.isStopped = true;
            enemyNavMesh.speed = 0;
            //enemyNavMesh.enabled = false;
            this.enabled = false;

        }

        distanceToTarget = Vector3.Distance(target.position, transform.position);
        
        if (isProvoked)
        {
            EngageTarget();
        }
           
        else if (distanceToTarget <= chaseRange)
        {
            isProvoked = true;
        }


    }


    public void OnDamageTaken()
    {
        isProvoked = true;


    }
    
    private void EngageTarget()
    {
       
        if (distanceToTarget >= enemyNavMesh.stoppingDistance)
        {
            ChaseTarget();
        }
        
        else if (distanceToTarget <= enemyNavMesh.stoppingDistance)
        {
            AttackTarget();
        }

    }

    private void ChaseTarget()
    {
        FaceTarget();
        GetComponent<Animator>().SetTrigger("Move");
        GetComponent<Animator>().SetBool("Attack",false);
        enemyNavMesh.SetDestination(target.transform.position);
        
    }

    private void AttackTarget()
    {
        GetComponent<Animator>().SetBool("Attack",true);
        Debug.Log("I am attacking to player");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75f);  
        Gizmos.DrawSphere(transform.position,chaseRange);
        
    }

    
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnSpeed*Time.deltaTime);


    }
    
    
    
}
