using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceWar3D
{
    public class PlayerHealth : MonoBehaviour
    {
        public int maxHealth;
        public int currentHealth { get; set; }
        public int index { get; set; }
        public List<GameObject> healthUI;

        delegate void OnPlayerDeath();
        private OnPlayerDeath onPlayerDeath;
        
      
        private void OnEnable()
        {
            Player.OnTakeDamage += TakeDamage;
            onPlayerDeath += PlayerDeath;
        }

        private void OnDisable()
        {
            Player.OnTakeDamage -= TakeDamage;
            onPlayerDeath -= PlayerDeath;
        }
        
        private void Start()
        {
            index = 0;
            currentHealth = maxHealth;

            for (int i = 0; i < currentHealth; i++)
            {
                healthUI[i].SetActive(true);
            }
        }

        private void Update()
        {
           
        }


        void TakeDamage()
        {
            currentHealth--;
            
            healthUI[index].SetActive(false);
            index++;
            
            if (currentHealth <= 0)
                onPlayerDeath?.Invoke();
            
            Debug.Log("On Take Damage");
        }
        
        private void PlayerDeath()
        {
            //game over
            Debug.Log("PlayerDeath");
            currentHealth = 0;
        }


    }
}
