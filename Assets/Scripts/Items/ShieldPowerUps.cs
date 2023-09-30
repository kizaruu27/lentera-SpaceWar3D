using System;
using System.Collections;
using System.Collections.Generic;
using SpaceWar3D;
using UnityEngine;

namespace SpaceWar3D
{
    public class ShieldPowerUps : Items
    {
        [SerializeField] private GameObject shieldObject;
    
        private void OnEnable()
        {
            Player.OnGetShield += ActivateShield;
        }

        private void OnDisable()
        {
            Player.OnGetShield -= ActivateShield;
        }

        void ActivateShield()
        {
            StartCoroutine(ShieldActive());
        }

        IEnumerator ShieldActive()
        {
            shieldObject.SetActive(true);
            yield return new WaitForSeconds(itemLifeTime);
            shieldObject.SetActive(false);
        }
    }
}

