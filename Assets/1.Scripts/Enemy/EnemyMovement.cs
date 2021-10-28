using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private Transform playerTr;
    private NavMeshAgent nav;
    private EnemyHealth enemyHealth;

    private void Awake()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if(enemyHealth.currentHealth > 0)
        {
            nav.SetDestination(playerTr.position);
        }
    }
}
