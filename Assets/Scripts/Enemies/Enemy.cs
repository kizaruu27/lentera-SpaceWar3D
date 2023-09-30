using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class ini dijadiin singleton
namespace SpaceWar3D
{
    public class Enemy : MonoBehaviour
    {
        private EnemySpawner enemySpawner;
        private WaveConfigSO waveConfig;
        private List<Transform> wayPoints;
        private int wayPointIndex = 0;

        public event Action OnHit;

        private void Awake()
        {
            enemySpawner = FindObjectOfType<EnemySpawner>();
        }

        private void Start()
        {
            waveConfig = enemySpawner.GetCurrentWave();
            wayPoints = waveConfig.GetWaypoint();
            transform.position = wayPoints[wayPointIndex].position;
        }

        private void Update()
        {
            FollowPath();
        }

        private void FollowPath()
        {
            if (wayPointIndex < wayPoints.Count)
            {
                Vector3 targetPosition = wayPoints[wayPointIndex].position;
                float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);

                if (transform.position == targetPosition)
                {
                    wayPointIndex++;
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") || other.CompareTag("Projectile"))
            {
                OnHit?.Invoke();
            }
        }
    }
    
}
