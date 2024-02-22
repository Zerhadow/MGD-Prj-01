using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public enum SelectedUnit {
        None,
        T1,
        MS1
    }
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
    public GameObject unitMenu;
    [Header("Player Dependencies")]
    public int silverCost;
    public int goldCost;
    [Header("Battle Dependencies")]
    public TMP_Text playerPowerText;
    public TMP_Text enemyPowerText;
    public GameObject winPrompt;
    public GameObject losePrompt;
    [Header("Unit Dependencies")]
    public GameObject levelUpBtn;
    public SelectedUnit unitSelected;
    public GameObject t1UnitObj;
    public TMP_Text t1PowerText;
    public TMP_Text t1FragmentText;

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
        _stateMachine.ChangeState(_stateMachine.UnitState);
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

    public void levelUpUnit() {
        if(unitSelected == SelectedUnit.T1) {
            gameController.PlayerController.LevelUpUnit("T1");
            TankBase t1 = gameController.PlayerController.GetTank("T1");
            t1PowerText.text = "Power \n" + t1.Power;
            t1FragmentText.text = "Fragments " + t1.fragments;
        }
    }

    public void T1UnitPage() 
    {
        if(gameController.PlayerController.GetTank("T1") != null) { // Check if they have the tank
            unitSelected = SelectedUnit.T1;
            TankBase t1 = gameController.PlayerController.GetTank("T1");
            t1PowerText.text = "Power \n" + t1.Power;
            t1FragmentText.text = "Fragments " + t1.fragments;
            _stateMachine.ChangeState(_stateMachine.UnitPageState);
        } else { Debug.Log("Player doesn't have tank yet"); }
    }
}