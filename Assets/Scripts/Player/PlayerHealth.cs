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
        public static bool isDead;
        
        public List<GameObject> healthUI;

        delegate void OnPlayerDeath();
        private OnPlayerDeath onPlayerDeath;

        public event Action playerDeathEvent;
        public static event Action onSaveScore;
      
        private void OnEnable()
        {
            isDead = false;
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
            isDead = true;
            currentHealth = 0;
            SoundManager.Instance.PlayExplosionClip();
            playerDeathEvent?.Invoke();
            onSaveScore?.Invoke();
            // Time.timeScale = 0;
            Destroy(gameObject);
        }


    }
}
