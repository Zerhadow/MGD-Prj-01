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

        // Disables everything on the canvas
        // Iterate through all child GameObjects
        foreach (Transform child in _controller.Canvas.transform)
        {
            // Set each child GameObject to inactive
            child.gameObject.SetActive(false);
        }

        // Activate canva elems
        _controller.Instructions.SetActive(true);
        _controller.StateIdicator.SetActive(true);
        _controller.stateName.text = "Setup State";
    }

    public override void Update()
    {
        base.Update();

        //check for tap input
        if(Input.GetMouseButtonDown(0)) {
            _controller.Instructions.SetActive(false);
            _stateMachine.ChangeState(_stateMachine.PlayState);
        }
        
        // after certain amount of time, trigger intro anim
    }

    public override void Exit() {
        base.Exit();
    }
}
