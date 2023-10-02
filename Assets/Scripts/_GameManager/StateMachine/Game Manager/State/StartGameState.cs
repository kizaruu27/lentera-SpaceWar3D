using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameState : GameBaseState
{
    public StartGameState(GameStateMachine stateMachine) : base(stateMachine) { }

    private float time;
    
    public override void Enter()
    {
        Debug.Log("Enter Start Game");
        stateMachine.GameOverUI.SetActive(false);
        time = stateMachine.GameStartTime;
    }

    public override void Tick(float deltaTIme)
    {
        Debug.Log("Waiting Game");
        
        stateMachine.MenuUI.SetActive(false);
        
        stateMachine.CountDownText.gameObject.SetActive(true);
        time -= deltaTIme;

        string formattedTime = time.ToString("F0");
        stateMachine.CountDownText.text = formattedTime;

        if (time <= 1)
        {
            stateMachine.CountDownText.gameObject.SetActive(false);
            time = 1;
            stateMachine.SwitchState(new RunGameState(stateMachine));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exit Start Game");
    }
}
