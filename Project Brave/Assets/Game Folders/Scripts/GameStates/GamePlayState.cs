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

        _controller.PlayAudio.Play();

        // Activate canva elems
        _controller.SummonBtn.SetActive(true);
        _controller.EnemyTextObj.SetActive(true);
        _controller.stateName.text = "Play State";
        _controller.enemyHPText.text = "Enemy Power: " + _controller.enemyPower;

        _controller.Music.Play();

        CalculateEnemyPower();
    }       

    public override void Update()
    {
        base.Update();
        // Check for player button press
        if(_controller.btnPress) {
            _controller.SummonBtn.SetActive(false);
            CalculatePlayerPower();
            Combat();
            _controller.btnPress = false;
        } else {
            // Make button fluctuate
        }
    }

    public override void Exit() {
        base.Exit();
        _controller.SummonBtn.SetActive(false);
        _controller.EnemyTextObj.SetActive(false);
        _controller.playerPower = 0; // reset player power
    }

    private void CalculateEnemyPower() {
        _controller.enemyPower  += 1;
    }

    public void CalculatePlayerPower() {
        int dSix = Random.Range(1,7); // 1 - 6      
        for(int i = 0; i < 3; i++) { // summons three tanks
            if(dSix <= 2) { // bad unit
                _controller.playerPower -= 1;
            } else if(dSix == 3 || dSix == 4) { // neutral unit
                _controller.playerPower += 1;
            } else { // good unit
                _controller.playerPower += 2;
            }
        }
    }

    private void Combat() { // Determine who wins
        Debug.Log(_controller.playerPower + " vs " + _controller.enemyPower);

        if(_controller.playerPower > _controller.enemyPower) {
            _stateMachine.ChangeState(_stateMachine.WinState);
            roundsWon += 1;
        } else {
            _stateMachine.ChangeState(_stateMachine.LoseState);
        }
    }
}