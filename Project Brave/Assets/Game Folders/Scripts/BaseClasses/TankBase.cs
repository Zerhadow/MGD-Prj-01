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
    public int Level = 1;
    public float Power;
    public int fragments;
    private int expNeeded = 0;

    public void LevelUp() {
        expNeeded = Level;

        if(fragments >= expNeeded) {
            Power += Random.Range(100, 200);
            fragments -= expNeeded;
            Debug.Log("Unit leveled up");
        } else { Debug.Log("Not enough fragments"); }
    }
}
