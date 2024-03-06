using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameController gameController;
    public int silver;
    public int gold;
    public bool startFight;
    [SerializeField] public List<TankBase> Squad = new List<TankBase>();
    [SerializeField] public List<TankBase> NormalGachaPool = new List<TankBase>();
    [SerializeField] public List<TankBase> SpecialGachaPool = new List<TankBase>();
    private string tankPulledName;
    
    private void Awake() {
        gameController = GetComponentInParent<GameController>();
    }
    
    public void GachaTime(int type) {
        if(type == 1) { // normal rates
            int randIdx = Random.Range(0,NormalGachaPool.Count);
            TankBase tankPull = NormalGachaPool[randIdx];
            tankPulledName = tankPull.tankPrefab.name;
            Debug.Log("You pulled: " + tankPulledName);
            GachaPull(tankPull);
        }

        if(type == 2) { // special rates
            int randIdx = Random.Range(0,SpecialGachaPool.Count);
            TankBase tankPull = SpecialGachaPool[randIdx];
            tankPulledName = tankPull.tankPrefab.name;
            Debug.Log("You pulled: " + tankPulledName);
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

    public void DisplayTankSummoned() {
        gameController.UI.summonBkg.SetActive(true);

        // disables all tank imgs so they can be set based on pull
        foreach (Transform child in gameController.UI.tankImgParent.transform) {
            // Set each child GameObject to inactive
            child.gameObject.SetActive(false);
        }
        
        if (tankPulledName == "T1") {
            gameController.UI.tankImgParent.transform.GetChild(0).gameObject.SetActive(true);
            gameController.UI.tankName.text = "T1";
        }

        if (tankPulledName == "MS-1") {
            gameController.UI.tankImgParent.transform.GetChild(1).gameObject.SetActive(true);
            gameController.UI.tankName.text = "MS-1";
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
