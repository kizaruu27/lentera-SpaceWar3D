using System.Collections;
using System.Collections.Generic;
using SpaceWar3D;
using UnityEngine;

public class RunGameState : GameBaseState
{
    public RunGameState(GameStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InstantiateGameObjects();
        stateMachine.GetGameObjectsReference();
    }

    public override void Tick(float deltaTIme)
    {
        Debug.Log("Game is Running");
    }

    public override void Exit()
    {
        Debug.Log("End Game");
    }
}
