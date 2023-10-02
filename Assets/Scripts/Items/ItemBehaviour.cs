using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceWar3D
{
    public class ItemBehaviour : MonoBehaviour
    {
        [SerializeField] private float itemLifeTime;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float moveSpeed;

        private void OnEnable()
        {
            PlayerHealth.playerDeathEvent += DestroyItem;
        }

        private void OnDisable()
        {
            PlayerHealth.playerDeathEvent -= DestroyItem;
        }

        private void Awake()
        {
            playerTransform = FindObjectOfType<Player>().transform;
        }
        
        void Start()
        {
            Destroy(gameObject, itemLifeTime);
        }
        
        private void LateUpdate()
        {
            if (playerTransform != null)
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }

        void DestroyItem()
        {
            Destroy(gameObject);
        }
    }
}
