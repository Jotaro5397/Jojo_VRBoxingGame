using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    public float walkSpeed = 5f;
    private float enemyHealth = 100f;
    private bool inRange;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Transform player;

    Animator animator;

    #region STATES
    [SerializeField]
    // Movement Animation States //
    const string ENEMY_IDLE = "Enemy_Idle";
    const string ENEMY_LSWALKFORWARD = "LSForward";
    const string ENEMY_STEPFORWARD = "StepForward";
    const string ENEMY_WALKFORWARD = "walkingForward";
    const string ENEMY_STEPBACK = "stepBack";
    const string ENEMY_LSSTEPLEFT = "LSLeft";
    const string ENEMY_STEPLEFT = "StepLeft";
    const string ENEMY_LSSTEPRIGHT = "LSRight";
    const string ENEMY_STEPRIGHT = "StepRight";
    //================================================//
    // Attacking Animation States //
    const string ENEMY_COMBO1 = "Combo1";
    const string ENEMY_COMBO2 = "Combo2";
    const string ENEMY_HEAVYHOOk = "HeavyHook";
    const string ENEMY_LEFTJAB = "LeftJab";
    const string ENEMY_LEFTBODYHOOK = "LeftBodyHook";
    const string ENEMY_LIGHTHOOK = "LightHook";
    const string ENEMY_RIGHTJABCROSS = "RightJabCross";
    //Hit Animation States//
    //========================================================//
    const string ENEMY_HEADHIT = "HeadHit1";
    const string ENEMY_HEADHITLEFT = "HeadHitLeft";
    const string ENEMY_BIGSTOMACHHIT = "BigStomachHit";
    const string ENEMY_HITTOBODY = "HitToBody";
    const string ENEMY_BIGUPPERHIT = "BigUppercut";
    //Block Aimation Sates//
    //======================================================//
    const string ENEMY_ISBLOCK = "CenterBlock";
    #endregion
        

    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent.speed = walkSpeed;
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Get the player's movement input (you need to implement this based on your input system).
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Determine the animation state based on player's movement input.
            if (Mathf.Approximately(horizontalInput, 0f) && Mathf.Approximately(verticalInput, 0f))
            {
                ChangeAnimationState(ENEMY_IDLE);
            }
            else if (verticalInput > 0)
            {
                ChangeAnimationState(ENEMY_WALKFORWARD);
            }
            else if (verticalInput < 0)
            {
                ChangeAnimationState(ENEMY_STEPBACK);
            }
            else if (horizontalInput < 0)
            {
                ChangeAnimationState(ENEMY_STEPLEFT);
            }
            else if (horizontalInput > 0)
            {
                ChangeAnimationState(ENEMY_STEPRIGHT);
            }
        }
    }
}
