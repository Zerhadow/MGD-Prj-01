using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSummonState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    public GameSummonState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("STATE: Summon State");

        // Activate canva elems
        _controller.stateName.text = "Summon State";
        _controller.UI.summonMenu.SetActive(true);
        _controller.UI.footer.SetActive(true);
    }

    public override void Update()
    {
        base.Update();

        // if button press, deactive summon notif
        if(Input.GetMouseButtonDown(0)) { // checks tap input
            _controller.UI.summonBkg.SetActive(false);
        }
    }

    public override void Exit() {
        base.Exit();
        _controller.UI.summonMenu.SetActive(false);
    }
}
