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
    [SerializeField] private PlayerController _playerController;

    [Header("State Idicators")]
    [SerializeField] private AudioSource _setupAudio;
    [SerializeField] private AudioSource _playAudio;
    [SerializeField] private AudioSource _winAudio;
    [SerializeField] private AudioSource _loseAudio;


    [Header("Audio Cues")]
    [SerializeField] private AudioSource _winCue;
    [SerializeField] private AudioSource _loseCue;
    [Header("PlayState Dependencies")]
    [SerializeField] private AudioSource _music;
    public TMP_Text stateName;
    public int enemyPower;

    public TouchInput Input => _input;
    public UIController UI => _ui;
    public PlayerController PlayerController => _playerController;
    public AudioSource SetupAudio => _setupAudio;
    public AudioSource PlayAudio => _playAudio;
    public AudioSource WinAudio => _winAudio;
    public AudioSource LoseAudio => _loseAudio;
    public AudioSource WinCue => _winCue;
    public AudioSource LoseCue => _loseCue;
    public AudioSource Music => _music;
}
