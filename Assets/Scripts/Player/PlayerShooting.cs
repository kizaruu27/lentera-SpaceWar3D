using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float shootInterval = 3;
    [SerializeField] GameObject projectilePrefab;

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
