using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace JA
{
    public class EnemyLocomotionManager : MonoBehaviour
    {
        EnemyManager enemyManager;
        LayerMask detectionLayer;

        private void Awake()
        {
            enemyManager = GetComponent<EnemyManager>();
        }

        public void HandleDetection()
        {
            Collider [] colliders = Physics.OverlapShphere(transform.position, EnemyManager.detectionRadius, detectionLayer);

            for (int i = 0; i < colliders.Lenth; i++)
            {
                
            }
        }
    }
}

