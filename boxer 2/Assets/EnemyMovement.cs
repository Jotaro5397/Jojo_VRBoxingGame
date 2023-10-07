using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform
    private NavMeshAgent agent;  // Reference to the NavMeshAgent component

    private void Start()
    {
        // Get references to the necessary components
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;  // Tag the player GameObject as "Player" in the Inspector
    }

    private void Update()
    {
        // Check if the player reference and agent are valid
        if (player != null && agent != null)
        {
            // Set the enemy's destination to the player's position
            agent.SetDestination(player.position);
        }
    }
}

