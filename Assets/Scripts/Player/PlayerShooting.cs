using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class ini dijadiin object pooling
namespace SpaceWar3D
{
    public class PlayerShooting : MonoBehaviour
    {
        public float startingShootInterval = 3f;
        public float shootInterval;
        [SerializeField] GameObject projectilePrefab;

        private void Awake()
        {
            shootInterval = startingShootInterval;
        }

        private void Start()
        {
            StartCoroutine(ShootCoroutine());
        }

        IEnumerator ShootCoroutine()
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(shootInterval);
            StartCoroutine(ShootCoroutine());
        }
    }
}
