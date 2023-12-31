using System;
using System.Collections;
using System.Collections.Generic;
using SpaceWar3D;
using UnityEngine;

namespace SpaceWar3D
{
    public class HealthPowerUps : Items
    {
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private int healthValue;

        private void OnEnable()
        {
            Player.OnGetHealthItems += GetHealth;
        }
    
        private void OnDisable()
        {
            Player.OnGetHealthItems -= GetHealth;
        }
    
        private void GetHealth()
        {
            SoundManager.Instance.PlayItemClip();
            if (playerHealth.currentHealth == playerHealth.maxHealth)
                return;
        
            playerHealth.currentHealth += healthValue;
        
            playerHealth.index--;
            playerHealth.healthUI[playerHealth.index].SetActive(true);
        
            Debug.Log("Get Health");
        }

    }
}

