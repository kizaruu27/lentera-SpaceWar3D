using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceWar3D
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance;
        
        private List<GameObject> poolObject;
        [SerializeField] int poolAmmount = 10;

        [SerializeField] private GameObject projectilePrefab;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            poolObject = new List<GameObject>();
            GameObject go;
            for (int i = 0; i < poolAmmount; i++)
            {
                go = Instantiate(projectilePrefab);
                go.SetActive(false);
                poolObject.Add(go);
            }
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < poolAmmount; i++)
            {
                if (!poolObject[i].activeInHierarchy) return poolObject[i];
            }

            return null;
        }
    }
}

