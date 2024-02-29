using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    float roundsWon = 0;

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("STATE: Game Play");

        _controller.audioController.PlayAudio.Play();

        // Activate canva elems
        _controller.stateName.text = "Battle State";
        _controller.UI.battleMenu.SetActive(true);
        _controller.UI.winPrompt.SetActive(false);
        _controller.UI.losePrompt.SetActive(false);

        _controller.audioController.BattleMusic.Play();


        _controller.UI.enemyPowerText.text = "Enemy Power: " + _controller.enemyPower;
        _controller.UI.playerPowerText.text = "Player Power: " + _controller.PlayerController.GetTotalPower();

        CalculateEnemyPower();
    }       

    public override void Update()
    {
        base.Update();
        // Check for player button press
        if(_controller.PlayerController.startFight) {
            DetermineWinner();
            _controller.PlayerController.startFight = false;
        }
    }

    public override void Exit() {
        base.Exit();
        _controller.UI.battleMenu.SetActive(false);
        // _controller.playerPower = 0; // reset player power

        _controller.audioController.BattleMusic.Stop();
    }

    private void CalculateEnemyPower() {
        int newPower = (int)(roundsWon * 100);
        _controller.enemyPower  += newPower;
    }

    private void DetermineWinner() {
        if(_controller.PlayerController.GetTotalPower() > _controller.enemyPower) {
            _stateMachine.ChangeState(_stateMachine.WinState);
            roundsWon += 1;
        } else {
            _stateMachine.ChangeState(_stateMachine.LoseState);
        }
    }
}