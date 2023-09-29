using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceWar3D
{
    public class EnemyBehaviour : MonoBehaviour
    {
        [SerializeField] private EnemyPathfinder enemy;

        private void OnEnable()
        {
            enemy.OnHit += DestroyEnemy;
        }

        private void OnDisable()
        {
            enemy.OnHit -= DestroyEnemy;
        }

        private void DestroyEnemy()
        {
            Destroy(gameObject);
        }
    }
}


