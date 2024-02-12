using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A template state to duplicate
public class GameTMPState : State
{
private GameFSM _stateMachine;
    private GameController _controller;

    public GameTMPState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("STATE: Template State");
    }

    public override void Exit() {
        base.Exit();
    }
}
