using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    float victoryClear = 0;

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("STATE: Game Play");

        // have tanks start idle combat
        
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit() {
        base.Exit();

        // remove all sounds of combat but continue number of victories at the level
    }
}
