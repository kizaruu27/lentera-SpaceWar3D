using System;
using System.Collections;
using System.Collections.Generic;
using SpaceWar3D;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceWar3D
{
    public class DropItem : MonoBehaviour
    {
        [SerializeField] private EnemyHealth enemyHealth;
        public List<ItemSpawnRate> itemsRate;
    
        private void OnEnable()
        {
            enemyHealth.OnDropItem += SpawnItem;
        }
    
        private void OnDisable()
        {
            enemyHealth.OnDropItem -= SpawnItem;
        }
    
        GameObject getItem()
        {
            int limit = 0;
    
            foreach(ItemSpawnRate osr in itemsRate)
            {
                limit += osr.itemRate;
            }
    
            int random = Random.Range(0, limit);
    
            foreach (ItemSpawnRate osr in itemsRate)
            {
                if (random < osr.itemRate)
                {
                    return  osr.itemPrefab;
                }
                else
                {
                    random -= osr.itemRate;
                }
            }
            return null;
        }
    
        public void SpawnItem()
        {
            GameObject go = getItem();
    
            if ( go != null)
            {
                Instantiate(go, transform.position, Quaternion.identity);
            }
    
        }
    }
}

