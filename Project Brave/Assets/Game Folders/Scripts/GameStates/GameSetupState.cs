using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("STATE: Game Setup");
        Debug.Log("Load Save Data");
        Debug.Log("Trigger intro");
        Debug.Log("Go to Title Screen");
    }

    public override void Exit() {
        base.Exit();
    }
}
