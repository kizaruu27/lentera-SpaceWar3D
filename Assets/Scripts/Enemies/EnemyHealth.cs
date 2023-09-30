using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceWar3D
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private Enemy enemy;
        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth;

        delegate void OnEnemyDeath();
        private OnEnemyDeath onEnemyDeath;

        private void Start()
        {
            currentHealth = maxHealth;
        }

        private void OnEnable()
        {
            enemy.OnHit += EnemyTakeDamage;
            onEnemyDeath += EnemyDeath;
        }
        
        private void OnDisable()
        {
            enemy.OnHit -= EnemyTakeDamage;         
            onEnemyDeath -= EnemyDeath;

        }
        
        private void EnemyTakeDamage()
        {
            currentHealth--;

            if (currentHealth <= 0)
                onEnemyDeath?.Invoke();
        }
        
        private void EnemyDeath()
        {
            // drop item disini
            Destroy(gameObject);
        }
    }
}


