using System;
using System.Collections;
using System.Collections.Generic;
using SpaceWar3D;
using TMPro;
using UnityEngine;

public class GameStateMachine : StateMachine
{
    // singleton harus di revisi nanti
    public static GameStateMachine Instance;
    
    // start game component
    [field: SerializeField] public float GameStartTime { get; set; }
    [field: SerializeField] public TextMeshProUGUI CountDownText { get; set; } 
    [field: SerializeField] public GameObject MenuUI { get; set; }

    // run game component
    [field: SerializeField] public Player PlayerPrefab { get; set; }
    [field: SerializeField] public EnemySpawner EnemySpawner { get; set; }
    [field: SerializeField] public EnemySpawner InGameEnemySpawner { get; set; }

    // end game component
    [field: SerializeField] public GameObject GameOverUI { get; set; }
    [field: SerializeField] public ScoreManager ScoreManager { get; set; }
    [field: SerializeField] public GameObject PlayerUI { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void PlayGame()
    {
        SwitchState(new StartGameState(this));
    }

    public void EndGame()
    {
        SwitchState(new EndGameState(this));
    }

    public void InstantiateGameObjects()
    {
        Instantiate(PlayerPrefab);
        Instantiate(EnemySpawner);
    }

    public void GetGameObjectsReference()
    {
        InGameEnemySpawner = FindObjectOfType<EnemySpawner>();
        ScoreManager = FindObjectOfType<ScoreManager>();
        PlayerUI = GameObject.Find("PlayerUICanvas");
    }

    public void DestroyInGameGameobjects()
    {
        Destroy(InGameEnemySpawner.gameObject);
        Destroy(ScoreManager.gameObject);
        Destroy(PlayerUI);
    }
}
