using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JA
{
    public class PlayerStats : CharacterStats
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;
        
        private Animator animator;

        HealthBar healthBar;
        

        private void Awake()
        {
            healthBar = FindObjectOfType<HealthBar>();

        }
        
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
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
