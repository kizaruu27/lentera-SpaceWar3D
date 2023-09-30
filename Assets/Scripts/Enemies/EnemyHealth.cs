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

        public event Action OnDropItem;
        public static event Action OnGetScore;

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
        
        private void Start()
        {
            currentHealth = maxHealth;
        }
        
        private void EnemyTakeDamage()
        {
            currentHealth--;
            SoundManager.Instance.PlayExplosionClip();

            if (currentHealth <= 0)
                onEnemyDeath?.Invoke();
        }
        
        private void EnemyDeath()
        {
            OnDropItem?.Invoke();
            OnGetScore?.Invoke();
            Destroy(gameObject);
        }
    }
}


