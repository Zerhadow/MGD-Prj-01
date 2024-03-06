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

        _controller.audioController.SetupAudio.Play();
        _controller.audioController.Music.Play();

        // Disables everything on the canvas
        // Iterate through all child GameObjects
        foreach (Transform child in _controller.UI.canvas.transform)
        {
            // Set each child GameObject to inactive
            child.gameObject.SetActive(false);
        }

        // Activate canva elems
        _controller.UI.instructions.SetActive(true);
        _controller.UI._stateIdicator.SetActive(true);
        _controller.stateName.text = "Setup State";
    }

    public override void Update()
    {
        base.Update();

        //check for tap input
        if(Input.GetMouseButtonDown(0)) {
            _controller.UI.instructions.SetActive(false);
            _stateMachine.ChangeState(_stateMachine.LobbyState);
        }
        
        // after certain amount of time, trigger intro anim
    }

    public override void Exit() {
        base.Exit();
    }
}
