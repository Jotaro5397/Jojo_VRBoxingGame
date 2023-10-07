using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    public float walkSpeed = 5f;
    private float enemyHealth = 100f;
    private bool inRange;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    Transform target;
    UnityEngine.AI.NavMeshAgent agent;
    
   

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

        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMeshAgent.speed = walkSpeed;
    }   
    

    
    
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        // ask if the player is in range or not and if the enemy is dead or not
        ChasePlayer();
        
   
    }
    void ChasePlayer()
    {
        agent.updateRotation = false;
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), walkSpeed * Time.deltaTime);
        agent.updatePosition = false;
       
    }
    
}
