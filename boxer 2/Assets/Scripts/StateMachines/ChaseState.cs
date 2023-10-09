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


    // Indicates if an attack is currently in progress
    private bool isAttacking = false;

    public Animator animator;

    public override State RunCurrentState()
    {
        UpdateAttackRangeStatus();

        if (isInAttackRange)
        {
            
            RotateAroundPlayer();
            return attackState; // Transition to AttackState
        }

        ChasePlayer();
        return this; // Stay in ChaseState
    }

    private void UpdateAttackRangeStatus()
    {
        float distanceToPlayer = Vector3.Distance(enemy.position, player.position);
        isInAttackRange = distanceToPlayer <= attackRange;
    }

    private void ChasePlayer()
    {
        Vector3 direction = (player.position - enemy.position).normalized;

        // Move towards the player
        enemy.position += direction * chaseSpeed * Time.deltaTime;

        // Look at the player, but only adjust the Y rotation
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        enemy.rotation = Quaternion.Slerp(enemy.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        enemy.eulerAngles = new Vector3(0, enemy.eulerAngles.y, 0);
        Vector3 localDir = enemy.InverseTransformDirection(direction);

       
        animator.SetFloat("Yaxis", localDir.x * chaseSpeed);
        animator.SetFloat("Xaxis", localDir.z * chaseSpeed);
    }

    private void RotateAroundPlayer()
    {
        enemy.RotateAround(player.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
