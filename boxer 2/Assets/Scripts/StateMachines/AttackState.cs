using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{

    [SerializeField]
    private const string ATTACK1 = "ComboPunch";
    private const string ATTACK2 = "Combo1";
    private const string ATTACK3 = "HeavyHook";
    private const string ATTACK4 = "LeftBodyHook";
    private const string ATTACK5 = "LeftJab";
    private const string ATTACK6 = "LightHook";
    private const string ATTACK7 = "RightJabCross";

    private string[] attackAnimations = { ATTACK1, ATTACK2, ATTACK3, ATTACK4, ATTACK5, ATTACK6, ATTACK7 };

    public AttackState attackState;
    public Transform enemy;
    public Transform player;
    public float attackRange = 3f;
    public bool isInAttackRange = false;

    private string lastAttackAnimation = "";

    private bool isAttacking = false;

    public ChaseState chaseState;

    public Animator animator;

    public override State RunCurrentState()
    {
        UpdateAttackRangeStatus();

        if (!isInAttackRange)
        {
            return chaseState; // Transition to ChaseState
        }

        if (!isAttacking)
        {
            RandomAttack();
        }

        return this; // Stay in AttackState
    }

    private void UpdateAttackRangeStatus()
    {
        float distanceToPlayer = Vector3.Distance(enemy.position, player.position);
        isInAttackRange = distanceToPlayer <= attackRange;
    }


    private void RandomAttack()
    {

        string selectedAttack = attackAnimations[Random.Range(0, attackAnimations.Length)];

        // Play the selected attack animation
        animator.Play(selectedAttack);

        // Set the lastAttackAnimation and isAttacking flag
        lastAttackAnimation = selectedAttack;
        isAttacking = true;

        // Start checking when the animation is completed
        StartCoroutine(CheckIfAnimationFinished(selectedAttack));
    }
    private IEnumerator CheckIfAnimationFinished(string animationName)
    {
        // Ensure the current animation state and name before checking the normalized time
        while (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) &&
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }

        // Reset the isAttacking flag
        isAttacking = false;
    }
}
