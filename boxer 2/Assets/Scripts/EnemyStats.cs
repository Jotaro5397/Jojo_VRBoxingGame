using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JA
{
    public class EnemyStats : CharacterStats
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }
        // Start is called before the first frame update
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
        }
        
        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth =healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth= currentHealth - damage;
            animator.Play("HeadHit1");

            if(currentHealth<= 0)
            {
                currentHealth = 0;
                animator.Play("DEATH1");
                //HANDLE PLAYER DEATH
            }
        }
    }
}
