using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private TouchInput _input;
    [SerializeField] private GameObject _titleScreen;

    public TouchInput Input => _input;
    public GameObject TitleScreenObj => _titleScreen;
}
