using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLobbyState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameLobbyState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("STATE: Lobby State");

        // Activate canva elems
        _controller.stateName.text = "Lobby State";
        _controller.UI.lobbyMenu.SetActive(true);
        _controller.UI.header.SetActive(true);

        _controller.audioController.Music.Play();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit() {
        base.Exit();
        _controller.UI.lobbyMenu.SetActive(false);
    }
}
