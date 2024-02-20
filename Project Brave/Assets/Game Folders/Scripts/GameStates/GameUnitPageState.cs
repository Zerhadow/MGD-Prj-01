using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnitPageState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameUnitPageState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("STATE: Unit Page State");

        // Activate canva elems
        _controller.stateName.text = "Unit Page State";
        _controller.UI.unitMenu.SetActive(true);
        
        if(_controller.PlayerController.Squad.Count != 0) {
            if(_controller.PlayerController.CheckCopy("T1")) {
                _controller.UI.t1UnitObj.SetActive(true);
            }
        }
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit() {
        base.Exit();

        // Deactivate all unit pages
        _controller.UI.t1UnitObj.SetActive(false);
    }
}
