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
        _controller.UI.levelUpBtn.SetActive(true);
        
        if(_controller.UI.unitSelected == UIController.SelectedUnit.T1) {
            _controller.UI.t1UnitObj.SetActive(true);
        }

        if(_controller.UI.unitSelected == UIController.SelectedUnit.MS1) {
            _controller.UI.ms1UnitObj.SetActive(true);
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
        _controller.UI.ms1UnitObj.SetActive(false);
        _controller.UI.levelUpBtn.SetActive(false);

        _controller.UI.unitSelected = UIController.SelectedUnit.None;
        _controller.UI.unitMenu.SetActive(false);
    }
}
