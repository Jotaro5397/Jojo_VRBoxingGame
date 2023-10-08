using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JA
{
    public class EnemyManager : CharacterManager
    {
        bool isPerformingAction;


        [Header("A.I Settings")]
        public float detectionRadius;
        
        // the higher, and lower, respectively thease angles are, greater
        public float maximumDetectionAngle = 50;
        public float minimumDetectionAngle = -50;

        private void Awake()
        {

        }

        private void update()
        {

        }

        private void HandleCurrentAction()
        {

        } 
    }
}


