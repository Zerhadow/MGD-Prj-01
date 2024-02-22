using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int silver;
    public int gold;
    public bool startFight;
    [SerializeField] public List<TankBase> Squad = new List<TankBase>();
    [SerializeField] public List<TankBase> NormalGachaPool = new List<TankBase>();
    [SerializeField] public List<TankBase> SpecialGachaPool = new List<TankBase>();
    
    public void GachaTime(int type) {
        if(type == 1) { // normal rates
            int randIdx = Random.Range(0,NormalGachaPool.Count);
            TankBase tankPull = NormalGachaPool[randIdx];
            Debug.Log("You pulled: " + tankPull.tankPrefab.name);
            GachaPull(tankPull);
        }

        if(type == 2) { // special rates
            int randIdx = Random.Range(0,SpecialGachaPool.Count);
            TankBase tankPull = SpecialGachaPool[randIdx];
            Debug.Log("You pulled: " + tankPull.tankPrefab.name);
            GachaPull(tankPull);
        }
    }

    private void GachaPull(TankBase tank) {
        if(CheckCopy(tank.name)) { // if player already has tank, increase number of duplicates on that tank
            Debug.Log("Fragment " + tank.name + " added");
            AddFragment(tank.name);
            // maybe show player how many fragments they have
        } else { // add tank to squad
            tank.Power = Random.Range(100, 200);
            tank.fragments = 0;
            Squad.Add(tank);
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
    
    public float GetTotalPower() {
        float power = 0;

        foreach (TankBase tank in Squad) {
            power += tank.Power;
        }

        return power;
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

    public void LevelUpUnit(string name) {
        foreach (TankBase tank in Squad) {
            if(tank.name == name) {
                tank.LevelUp();
            }
        }
    }
}
