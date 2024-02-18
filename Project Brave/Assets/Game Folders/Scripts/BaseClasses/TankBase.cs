using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Tank", menuName = "Tank/Create new tank")]
public class TankBase : ScriptableObject
{
    [System.Serializable]
    public enum Rarity {
        Normal,
        Uncommon,
        Rare
    }
    public Rarity rarity;
    public GameObject tankPrefab;
    public int Level { get; set; }
    public float Power;
}
