using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceWar3D
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private int playerHealth = 3;

        private void OnEnable()
        {
            player.OnTakeDamage += TakeDamage;
        }

        private void OnDisable()
        {
            player.OnTakeDamage -= TakeDamage;
        }

        void TakeDamage()
        {
            playerHealth--;
            Debug.Log("On Take Damage");
        }

    }
}
