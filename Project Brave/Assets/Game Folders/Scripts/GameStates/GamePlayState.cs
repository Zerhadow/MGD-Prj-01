using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GamePlayState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;
    float roundsWon = 0;
    private bool firstRound = true; // intianiates first round

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

        _controller.audioController.Music.Stop();
        _controller.audioController.BattleMusic.Play();

        _controller.UI.footer.SetActive(true);

        CalculateEnemyPower();
        _controller.UI.enemyPowerText.text = "Enemy Power: \n" + _controller.enemyPower;
        _controller.UI.playerPowerText.text = "Player Power: \n" + _controller.PlayerController.GetTotalPower();
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
        _controller.audioController.Music.Play();
    }

    private void CalculateEnemyPower() {
        if(firstRound) {
            _controller.enemyPower = 100;
            firstRound = false;
        } else {
            int randNum = Random.Range(50, 100);
            int newPower = (int)(roundsWon * randNum);
            _controller.enemyPower  += newPower;
        }
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