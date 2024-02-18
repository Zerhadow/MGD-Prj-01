using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnitState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameUnitState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("STATE: Summon State");

        // Activate canva elems
        _controller.stateName.text = "Unit State";
        _controller.UI.unitMenu.SetActive(true);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit() {
        base.Exit();
        _controller.UI.unitMenu.SetActive(false);
    }
}
