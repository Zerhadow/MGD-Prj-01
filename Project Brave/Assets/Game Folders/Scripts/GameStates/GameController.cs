using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TouchInput _input;
    [SerializeField] private GameObject _instructions;
    [SerializeField] private GameObject _canvas;

    [Header("State Idicators")]
    [SerializeField] private GameObject _stateIdicator;

    [Header("Audio Cues")]
    [SerializeField] private AudioSource _winAudio;
    [SerializeField] private AudioSource _loseAudio;
    [Header("Condition Prompts")]
    [SerializeField] private GameObject _winPrompt;
    [SerializeField] private GameObject _losePrompt;
    [Header("PlayState Dependencies")]
    [SerializeField] private GameObject _summonBtn;
    [SerializeField] private GameObject _enemyTextObj;
    public TMP_Text stateName;
    public TMP_Text enemyHPText;
    public int enemyPower;
    public int playerPower;
    public bool btnPress = false;

    public TouchInput Input => _input;
    public GameObject Instructions => _instructions;
    public GameObject Canvas => _canvas;
    public GameObject StateIdicator => _stateIdicator;
    public AudioSource WinAudio => _winAudio;
    public AudioSource LoseAudio => _loseAudio;
    public GameObject WinPrompt => _winPrompt;
    public GameObject LosePrompt => _losePrompt;
    public GameObject SummonBtn => _summonBtn;
    public GameObject EnemyTextObj => _enemyTextObj;

    public void SummonBtnPress() {
        btnPress = true;
    }
}
