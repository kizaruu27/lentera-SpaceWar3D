using System.Collections;
using System.Collections.Generic;
using SpaceWar3D;
using UnityEngine;

public class EndGameState : GameBaseState
{
    public EndGameState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.DestroyInGameGameobjects();
        stateMachine.GameOverUI.SetActive(true);
        UIManager.Instance.UpdateHighScore(PlayerPrefs.GetInt("HighScore"));
    }

    public override void Tick(float deltaTIme)
    {
        
    }

    public override void Exit()
    {
        
    }
}
