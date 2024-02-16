using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject canvas;
    public GameFSM _stateMachine;
    [Header("Setup Dependencies")]
    public GameObject instructions;
    [Header("Lobby Dependencies")]
    public GameObject lobbyMenu;
    public GameObject summonMenu;


    public bool SummonBtnPress() {
        return true;
    }

    public void ChangeToBattle() {
        _stateMachine.ChangeState(_stateMachine.PlayState);
    }

    public void ChangeToSummon() {
        _stateMachine.ChangeState(_stateMachine.SummonState);
    }

    public void ChangeToUnit() {
        // _stateMachine.ChangeState(_stateMachine.UnitState);
    }

    public void ChangeToLobby() {
        _stateMachine.ChangeState(_stateMachine.LobbyState);
    }
}
