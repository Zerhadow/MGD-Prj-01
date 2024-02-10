using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [field: SerializeField]
    public TouchInput Input{ get; private set; }
}
