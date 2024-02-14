using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameWinState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("STATE: Win State");

        _controller.WinAudio.Play();

        // Activate canva elems
        _controller.WinPrompt.SetActive(true);
        _controller.stateName.text = "Win State";

        // Provide audio cue
        _controller.WinCue.Play();
    }

    public override void Update() {
        base.Update();

        //check for tap input
        if(Input.GetMouseButtonDown(0)) {
            _stateMachine.ChangeState(_stateMachine.PlayState);
        }
    }

    public override void Exit() {
        base.Exit();
        _controller.WinPrompt.SetActive(false);
    }
}
