using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    public float walkSpeed = 5f;
    private float enemyHealth = 100f;
    private bool inRange;
    public Transform player;  // Reference to the player's Transform
    private NavMeshAgent agent;
    public float UpdateRate = 0.1f;
    
    Animator animator;

    public delegate void StateChangeEvent(EnemyState oldState, EnemyState newState);
    public StateChangeEvent OnStateChange;
    public float stopDistance = 0.2f;

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
        
    private float stoppingDistance = 1.0f;
    private string currentState;
    public EnemyState DefaultState;
    private EnemyState _state;
    public EnemyState State 
    {
        get
        {
            return _state;
        }
        set
        {
            OnStateChange?.Invoke(_state, value);
            _state = value;
        }
    }

    private Coroutine FollowCoroutine;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Awake()
    {
        
        OnStateChange += HandleStateChange;
        
    }

    private void OnDisable()
    {
        _state = DefaultState; // use _state to avoid triggering OnStateChange when recycling object in the pool
    }

    public void Spawn()
    {
        OnStateChange?.Invoke(EnemyState.Spawn, DefaultState);
    }

    // private IEnumerator FollowTarget()
    // {
    //     WaitForSeconds Wait = new WaitForSeconds(UpdateRate);
        
    //     while (gameObject.activeSelf)
    //     {
    //         if (agent.enabled)
    //         {
    //             agent.SetDestination(Player.position);
    //             Debug.Log("Setting destination to player position.");
    //         }
    //         yield return Wait;
    //     }
    // }
    
    private void FollowTarget()
    {
        if (player != null && agent != null)
        {
            // Set the enemy's destination to the player's position
            agent.SetDestination(player.position);
        }
        Debug.Log("Setting destination to player position.");
        // No need for a return statement when the return type is void.
    }

    private void Update()
    {
        if (player != null && agent != null)
        {
            // Set the enemy's destination to the player's position
            agent.SetDestination(player.position);
        }

        // Check the current state
        switch (State)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Attacking:
                break;
            case EnemyState.Chase:
                break;
            case EnemyState.Running:
                break;
        }
    }

    private void HandleStateChange(EnemyState oldState, EnemyState newState)
    {
        if (FollowCoroutine !=null)
        {
            StopCoroutine(FollowCoroutine);
        }
        switch(newState)
        {
            case EnemyState.Idle:

                break;
            case EnemyState.Attacking:
            
                break;
            case EnemyState.Chase:
                FollowTarget();
                Debug.Log("Chase Activated");

                break;
            case EnemyState.Running:
            
                break;
        }
    } 
}
