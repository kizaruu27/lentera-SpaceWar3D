using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceWar3D
{
    public class GameOverUIAnimation : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private GameObject gameOverUI;

        // private void OnEnable()
        // {
        //     playerHealth.playerDeathEvent += EnableGameOverUI;
        // }
        //
        // private void OnDisable()
        // {
        //     playerHealth.playerDeathEvent -= EnableGameOverUI;
        // }

        private void EnableGameOverUI()
        {
            gameOverUI.SetActive(true);
        }
    }

}
