using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyProjectile") || other.CompareTag("Enemy"))
            Destroy(other.gameObject);
    }
}
