using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class ini jadiin singleton

namespace SpaceWar3D
{
    public class EnemySpawner : Singleton<EnemySpawner>
    {
        [SerializeField] private List<WaveConfigSO> waveConfigs;
        [SerializeField] private float timeBetweenWaves;
        WaveConfigSO currentWave;
        void Start()
        {
            StartCoroutine(SpawnEnemyWaves());
        }

        IEnumerator SpawnEnemyWaves()
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }

            StartCoroutine(SpawnEnemyWaves());

        }

        public WaveConfigSO GetCurrentWave()
        {
            return currentWave;
        }
    }
}

