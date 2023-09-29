using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class ini jadiin singleton

namespace SpaceWar3D
{
    public class EnemySpawner : MonoBehaviour
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
           
        }

        public WaveConfigSO GetCurrentWave()
        {
            return currentWave;
        }
    }
}

