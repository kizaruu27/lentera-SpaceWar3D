using System;
using System.Collections;
using System.Collections.Generic;
using SpaceWar3D;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player playerPrefab;
    
    // private void Start()
    // {
    //     Instantiate(playerPrefab);
    // }

    public void PlayGame()
    {
        GameStateMachine.Instance.PlayGame();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
