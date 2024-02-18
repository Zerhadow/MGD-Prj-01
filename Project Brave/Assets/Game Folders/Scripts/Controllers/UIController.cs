using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject canvas;
    private GameFSM _stateMachine;
    private GameController gameController;
    public GameObject _stateIdicator;


    [Header("Header Dependencies")]
    public TMP_Text silver_text;
    public TMP_Text gold_text;
    [Header("Setup Dependencies")]
    public GameObject instructions;
    public GameObject header;
    [Header("Lobby Dependencies")]
    public GameObject lobbyMenu;
    public GameObject summonMenu;
    public GameObject battleMenu;
    [Header("Player Dependencies")]
    public int silverCost;
    public int goldCost;
    [Header("Battle Dependencies")]
    public TMP_Text playerPowerText;
    public TMP_Text enemyPowerText;
    public GameObject winPrompt;
    public GameObject losePrompt;

    private void Awake() {
        _stateMachine = GetComponentInParent<GameFSM>();
        gameController = GetComponentInParent<GameController>();
    }
    
    private void Update() {
        silver_text.text = "Silver: " + gameController.PlayerController.silver;
        gold_text.text = "Gold: " + gameController.PlayerController.gold;
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

    public void NormalSummonBtn() {
        if(gameController.PlayerController.silver >= silverCost) {
            gameController.PlayerController.silver -= silverCost;
            gameController.PlayerController.GachaTime(1);
        } else {
            Debug.Log("Not enough silver");
        }
    }

    public void SpecialSummonBtn() {
            // Debug.Log("Special summon");
            // playerController.gold -= goldCost;
            // playerController.GachaTime(2);
    }

    public void StartCombat() {
        Debug.Log("Start Combat");
        gameController.PlayerController.startFight = true;
    }
}
