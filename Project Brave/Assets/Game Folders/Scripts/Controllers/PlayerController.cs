using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int silver;
    public int gold;
    public float totalPower;
    public bool startFight;
    [SerializeField] public List<TankBase> Squad = new List<TankBase>();
    [SerializeField] public List<TankBase> NormalGachaPool = new List<TankBase>();
    [SerializeField] public List<TankBase> SpecialGachaPool = new List<TankBase>();

    private void Start() {
        totalPower = StartingPower();
    }
    
    public void GachaTime(int type) {
        if(type == 1) { // normal rates
            int randIdx = Random.Range(0,NormalGachaPool.Count);
            TankBase tankPull = NormalGachaPool[randIdx];
            Debug.Log("You pulled: " + tankPull.tankPrefab.name);

            if(CheckCopy(tankPull.name)) { // if player already has tank, increase number of duplicates on that tank
                Debug.Log("Fragment " + tankPull.name + " added");
                AddFragment(tankPull.name);
                // maybe show player how many fragments they have
            } else { // add tank to squad
                tankPull.Power = Random.Range(100, 200);
                Squad.Add(tankPull);
                AddPower(tankPull);
            }
        }

        if(type == 2) { // special rates
            int randIdx = Random.Range(0,SpecialGachaPool.Count - 1);
            TankBase tankPull = SpecialGachaPool[randIdx];
            Squad.Add(tankPull);
        }
    }

    private void AddFragment(string name)
    {
        foreach (TankBase tank in Squad) {
            if(tank.name == name) {
                tank.fragments += 1;
            }
        }
    }

    public float StartingPower() 
    {
        float startPwr = 0;

        foreach (TankBase tank in Squad) {
            startPwr += tank.Power;
        }

        return startPwr;
    }
    
    public void AddPower(TankBase newTank) {
        totalPower += newTank.Power;
    }

    public bool CheckCopy(string pulledTankName) 
    {
        foreach (TankBase tank in Squad) {
            if(tank.name == pulledTankName) {
                return true;
            }
        }

        return false;
    }

    public TankBase GetTank(string name) {
        foreach (TankBase tank in Squad) {
            if(tank.name == name) {
                return tank;
            }
        }

        return null;
    }
}
