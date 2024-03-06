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
    public GameObject footer;
    [Header("Lobby Dependencies")]
    public GameObject lobbyMenu;
    public GameObject summonMenu;
    public GameObject battleMenu;
    public GameObject unitMenu;
    [Header("Summon Dependencies")]
    public GameObject summonBkg;
    public GameObject tankImgParent;
    public TMP_Text tankName;
    public ParticleSystem summonParticle;
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
    public GameObject ms1UnitObj;
    public TMP_Text ms1PowerText;
    public TMP_Text ms1FragmentText;

    private void Awake() {
        _stateMachine = GetComponentInParent<GameFSM>();
        gameController = GetComponentInParent<GameController>();
    }
    
    private void Update() {
        silver_text.text = "Silver: " + gameController.PlayerController.silver;
        gold_text.text = "Gold: " + gameController.PlayerController.gold;
    }

    public void ChangeToBattle() {
        gameController.audioController.confirm.Play();
        _stateMachine.ChangeState(_stateMachine.PlayState);
    }

    public void ChangeToSummon() {
        gameController.audioController.confirm.Play();
        _stateMachine.ChangeState(_stateMachine.SummonState);
    }

    public void ChangeToUnit() {
        gameController.audioController.confirm.Play();
        _stateMachine.ChangeState(_stateMachine.UnitState);
    }

    public void ChangeToLobby() {
        gameController.audioController.confirm.Play();
        _stateMachine.ChangeState(_stateMachine.LobbyState);
    }

    public void NormalSummonBtn() {
        if(gameController.PlayerController.silver >= silverCost) {
            gameController.audioController.confirm.Play();
            gameController.PlayerController.silver -= silverCost;
            gameController.PlayerController.GachaTime(1);
            gameController.PlayerController.DisplayTankSummoned();
            summonParticle.Play();
        } else {
            Debug.Log("Not enough silver");
            gameController.audioController.deny.Play();
        }
    }

    public void SpecialSummonBtn() {
        if(gameController.PlayerController.gold >= goldCost) {
            gameController.audioController.confirm.Play();
            gameController.PlayerController.gold -= goldCost;
            gameController.PlayerController.GachaTime(2);
            gameController.PlayerController.DisplayTankSummoned();
            summonParticle.Play();
        } else {
            Debug.Log("Not enough gold");
            gameController.audioController.deny.Play();
        }
    }

    public void StartCombat() {
        Debug.Log("Start Combat");
        gameController.audioController.confirm.Play();
        gameController.PlayerController.startFight = true;
    }

    public void levelUpUnit() {
        if(unitSelected == SelectedUnit.T1) {
            gameController.PlayerController.LevelUpUnit("T1");
            TankBase t1 = gameController.PlayerController.GetTank("T1");
            t1PowerText.text = "Power \n" + t1.Power;
            t1FragmentText.text = "Fragments " + t1.fragments;
        }

        if(unitSelected == SelectedUnit.MS1) {
            gameController.PlayerController.LevelUpUnit("MS-1");
            TankBase ms1 = gameController.PlayerController.GetTank("MS-1");
            ms1PowerText.text = "Power \n" + ms1.Power;
            ms1FragmentText.text = "Fragments " + ms1.fragments;
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
        } else { 
            Debug.Log("Player doesn't have tank yet");
            gameController.audioController.deny.Play();
        }
    }

    public void MS1UnitPage() 
    {
        if(gameController.PlayerController.GetTank("MS-1") != null) { // Check if they have the tank
            unitSelected = SelectedUnit.MS1;
            TankBase ms1 = gameController.PlayerController.GetTank("MS-1");
            ms1PowerText.text = "Power \n" + ms1.Power;
            ms1FragmentText.text = "Fragments " + ms1.fragments;
            _stateMachine.ChangeState(_stateMachine.UnitPageState);
        } else { 
            Debug.Log("Player doesn't have tank yet");
            gameController.audioController.deny.Play();
        }
    }
}