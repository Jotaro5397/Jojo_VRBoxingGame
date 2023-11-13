using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform player;           // Reference to the player's transform
    public float moveSpeed = 3.0f;    // Speed at which the enemy chases the player
    public float stoppingDistance = 2.0f; // Distance at which the enemy stops chasing

    private bool isChasing = false;    // Flag to track if the enemy is chasing

    private void Update()
    {
        // Check if the player is in range to chase
        if (ShouldChasePlayer())
        {
            Chase();
        }
        else
        {
            StopChasing();
        }
    }

    private bool ShouldChasePlayer()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Return true if the distance is less than stoppingDistance
        return distanceToPlayer <= stoppingDistance;
    }

    private void Chase()
    {
        // Calculate the direction towards the player
        Vector3 direction = (player.position - transform.position).normalized;

        // Move the enemy towards the player
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Rotate to face the player (optional)
        transform.LookAt(player);

        // Flag that the enemy is chasing
        isChasing = true;
    }

    private void StopChasing()
    {
        // Reset the chasing flag
        isChasing = false;
    }
}

