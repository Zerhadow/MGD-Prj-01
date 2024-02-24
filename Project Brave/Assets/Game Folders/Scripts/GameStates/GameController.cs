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
    [SerializeField] private AudioController _audioController;

    public TMP_Text stateName;
    public int enemyPower;

    public TouchInput Input => _input;
    public UIController UI => _ui;
    public PlayerController PlayerController => _playerController;
    public AudioController audioController => _audioController;
}
