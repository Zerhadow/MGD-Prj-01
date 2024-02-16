using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TouchInput _input;
    [SerializeField] private UIController _ui;

    [Header("State Idicators")]
    [SerializeField] private GameObject _stateIdicator;
    [SerializeField] private AudioSource _setupAudio;
    [SerializeField] private AudioSource _playAudio;
    [SerializeField] private AudioSource _winAudio;
    [SerializeField] private AudioSource _loseAudio;


    [Header("Audio Cues")]
    [SerializeField] private AudioSource _winCue;
    [SerializeField] private AudioSource _loseCue;
    [Header("Condition Prompts")]
    [SerializeField] private GameObject _winPrompt;
    [SerializeField] private GameObject _losePrompt;
    [Header("PlayState Dependencies")]
    [SerializeField] private GameObject _summonBtn;
    [SerializeField] private GameObject _enemyTextObj;
    [SerializeField] private AudioSource _music;
    public TMP_Text stateName;
    public TMP_Text enemyHPText;
    public int enemyPower;
    public int playerPower;
    public bool btnPress = false;

    public TouchInput Input => _input;
    public UIController UI => _ui;
    public GameObject StateIdicator => _stateIdicator;
    public AudioSource SetupAudio => _setupAudio;
    public AudioSource PlayAudio => _playAudio;
    public AudioSource WinAudio => _winAudio;
    public AudioSource LoseAudio => _loseAudio;
    public AudioSource WinCue => _winCue;
    public AudioSource LoseCue => _loseCue;
    public GameObject WinPrompt => _winPrompt;
    public GameObject LosePrompt => _losePrompt;
    public GameObject SummonBtn => _summonBtn;
    public GameObject EnemyTextObj => _enemyTextObj;
    public AudioSource Music => _music;


    public void SummonBtnPress() {
        btnPress = true;
    }
}
