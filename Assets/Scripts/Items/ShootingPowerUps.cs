using System;
using System.Collections;
using System.Collections.Generic;
using SpaceWar3D;
using UnityEngine;

public class ShootingPowerUps : Items
{
    [SerializeField] private PlayerShooting[] playerShootings;
    [SerializeField] private float newShootInterval = 1;

    private void OnEnable()
    {
        Player.OnGetShootItems += ActivateTime;
    }

    private void OnDisable()
    {
        Player.OnGetShootItems -= ActivateTime;
    }

    void ActivateTime()
    {
        Debug.Log("Get Item");       
        StartCoroutine(ItemActive(itemLifeTime));

    }

    IEnumerator ItemActive(float lifeTime)
    {
        playerShootings[0].shootInterval = newShootInterval;
        playerShootings[1].shootInterval = newShootInterval;

        yield return new WaitForSeconds(lifeTime);
        playerShootings[0].shootInterval = playerShootings[0].startingShootInterval;
        playerShootings[1].shootInterval = playerShootings[1].startingShootInterval;
    }
    
}
