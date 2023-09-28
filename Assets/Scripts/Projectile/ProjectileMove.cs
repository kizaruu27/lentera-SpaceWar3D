using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceWar3D
{
    public class ProjectileMove : MonoBehaviour
    {
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private float bulletLifeTime;
        
        void Update()
        {
            transform.Translate(_projectileSpeed * Vector3.up * Time.deltaTime);
            Destroy(gameObject, bulletLifeTime);
        }
    }
}


