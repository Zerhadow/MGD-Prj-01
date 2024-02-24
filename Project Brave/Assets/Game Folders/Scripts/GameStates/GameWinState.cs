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

        _controller.audioController.WinAudio.Play();

        // Activate canva elems
        _controller.UI.winPrompt.SetActive(true);
        _controller.stateName.text = "Win State";

        // Provide audio cue
        _controller.audioController.WinCue.Play();

        // Give player gold & silver
        _controller.PlayerController.gold += 10;
        _controller.PlayerController.silver = CalculateSilver();
    }

    public override void Update() {
        base.Update();

        //check for tap input
        if(Input.GetMouseButtonDown(0)) {
            _stateMachine.ChangeState(_stateMachine.LobbyState);
        }
    }

    public override void Exit() {
        base.Exit();
        _controller.UI.winPrompt.SetActive(false);
    }

    private int CalculateSilver() {
        return (int)(_controller.PlayerController.GetTotalPower() - _controller.enemyPower);
    }
}
