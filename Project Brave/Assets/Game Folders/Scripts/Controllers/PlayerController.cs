using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [System.Serializable]
    public class Tank {
        [System.Serializable]
        public enum Rarity {
            Normal,
            Uncommon,
            Rare
        }
        public Rarity rarity;
        public GameObject tankPrefab;
        public int Level { get; set; }
        public float Power { get; set; }
    }    
    
    public int silver;
    public int gold;
    public float totalPower;
    public bool startFight;
    [SerializeField] public List<Tank> Squad = new List<Tank>();
    [SerializeField] public List<Tank> NormalGachaPool = new List<Tank>();
    [SerializeField] public List<Tank> SpecialGachaPool = new List<Tank>();

    private void Start() {
        totalPower = StartingPower();
    }
    
    public void GachaTime(int type) {
        if(type == 1) { // normal rates
            int randIdx = Random.Range(0,NormalGachaPool.Count);
            Tank tankPull = NormalGachaPool[randIdx];
            Debug.Log("You pulled: " + tankPull.tankPrefab.name);
            tankPull.Power = Random.Range(100, 200);
            Squad.Add(tankPull);
            AddPower(tankPull);
        }

        if(type == 2) { // special rates
            int randIdx = Random.Range(0,SpecialGachaPool.Count - 1);
            Tank tankPull = SpecialGachaPool[randIdx];
            Squad.Add(tankPull);
        }
    }

    public float StartingPower() 
    {
        float startPwr = 0;

        foreach (Tank tank in Squad) {
            startPwr += tank.Power;
        }

        return startPwr;
    }
    
    public void AddPower(Tank newTank) {
        totalPower += newTank.Power;
    }
}
