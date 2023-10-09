using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public AttackState attackState;
    public Transform enemy;
    public Transform player;
    public float chaseSpeed = 5f;
    public float rotationSpeed = 100f;
    public float attackRange = 3f;
    public bool isInAttackRange = false;    

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(enemy.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            isInAttackRange = true;
        }
        else
        {
            isInAttackRange = false;
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        Vector3 direction = (player.position - enemy.position).normalized;

        // Move towards the player
        enemy.position += direction * chaseSpeed * Time.deltaTime;

        // Look at the player
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        enemy.rotation = Quaternion.Slerp(enemy.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    public override State RunCurrentState()
    {
        if (isInAttackRange)
        {
            RotateAroundPlayer();
            return attackState;
        }
        return this;
    }

    private void RotateAroundPlayer()
    {
        enemy.RotateAround(player.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
