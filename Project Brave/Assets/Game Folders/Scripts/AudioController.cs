using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
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
    [SerializeField] private AudioSource battleMusic;

    [Header("SFX")]
    public AudioSource confirm;
    public AudioSource deny;

    public AudioSource SetupAudio => _setupAudio;
    public AudioSource PlayAudio => _playAudio;
    public AudioSource WinAudio => _winAudio;
    public AudioSource LoseAudio => _loseAudio;
    public AudioSource WinCue => _winCue;
    public AudioSource LoseCue => _loseCue;
    public AudioSource Music => _music;
    public AudioSource BattleMusic => battleMusic;
}
