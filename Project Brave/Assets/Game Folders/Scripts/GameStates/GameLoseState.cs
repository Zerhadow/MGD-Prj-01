using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// A template state to duplicate
public class GameLoseState : State
{
private GameFSM _stateMachine;
    private GameController _controller;

    public GameLoseState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("STATE: Lose State");

        _controller.audioController.LoseAudio.Play();

        // Activate canva elems
        _controller.stateName.text = "Lose State";
        _controller.UI.losePrompt.SetActive(true);

        // Provide audio cue
        _controller.audioController.LoseCue.Play();
    }

    public override void Update() {
        base.Update();

        //check for tap input
        if(Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public override void Exit() {
        base.Exit();
        _controller.audioController.Music.Stop();
    }
}
