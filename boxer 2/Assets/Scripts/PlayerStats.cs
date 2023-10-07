using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JA
{
    public class PlayerStats : CharacterStats
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        HealthBar healthbar;
        

        privtae void Awake()
        {
            healthbar = FindObjectOftType<HealthBar>()
        }
    }
}
