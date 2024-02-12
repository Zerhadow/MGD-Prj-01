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
        // Debug.Log("Load Save Data");
        Debug.Log("Trigger intro theme");
        // Debug.Log("Trigger intro");

        // Activate canva elems
        _controller.TitleScreenObj.SetActive(true);
    }

    public override void Update()
    {
        base.Update();

        //check for tap input
        if(Input.GetMouseButtonDown(0)) { 
            _stateMachine.ChangeState(_stateMachine.PlayState);
        }
        
        // after certain amount of time, trigger intro anim
    }

    public override void Exit() {
        base.Exit();

        // remove the intro screen
        _controller.TitleScreenObj.SetActive(false);
    }
}
