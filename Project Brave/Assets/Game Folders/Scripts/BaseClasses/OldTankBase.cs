using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public abstract class OldTankBase : MonoBehaviour
{
    [Header("Tank Stats")]
    [SerializeField] private int _maxHP = 3;
    public int currHP {get; private set;}
    [SerializeField] private int _firepower = 2; // dammage per shell
    [SerializeField] private int _pen = 1;

    [SerializeField] private int _armor = 1;
    [SerializeField] private float _ammo = 2; // number of secs between attack
    [SerializeField] private int _level = 1;
    [SerializeField] private int _exp = 1;

    [Header("FX")]
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioClip _hitSound;

    [Header("Objects")]
    [SerializeField] GameObject _playerObj;
    [SerializeField] GameObject _enemyObj;
    [SerializeField] OldTankBase _otherTank;

    private void Awake() { 
        currHP = _maxHP;

        _otherTank = _enemyObj.GetComponent<OldTankBase>();
    }
    protected virtual void OnHit(int enemyFirePwr, int enemyPen) { // if tank takes a hit
        if(enemyPen >= _armor) {
            currHP -= enemyFirePwr;
            currHP = Mathf.Clamp(currHP, 0, int.MaxValue);
            Debug.Log(transform.name + " takes " + currHP + " damage");

            if (currHP <= 0) {
                Die();
            }
        } else { // roll again to see if it hits, if not will miss
            // for now say dmg blocked
            Debug.Log(transform.name + " takes no damage");
        }
    } 

    protected virtual void Update() {
        Attack();
    }
    protected virtual void Attack() {
        bool reload = true;

        if(reload) { // OnHit other target
            _otherTank.OnHit(_otherTank._firepower, _otherTank._pen);
            reload = false;
        } else { // tank is reloading
            StartCoroutine(Reload());
            reload = true;
        }
    }

    public virtual IEnumerator Reload() 
    {
        yield return new WaitForSeconds(_ammo);
    }

    public virtual void LevelUp() // if exp is at necesary amount
    {  
        // these states will dependent on Vechicle type (defined in inherited classes)
        _level += 1;
        _maxHP += 100;
        _firepower += 20;
        _pen += 5;
        _armor += 1;
        _ammo -= 0.5f;
    }
    
    public virtual void Die()
    {
        // AudioHelper.PlayClip2D(_deathSound, 1, .1f);
        Debug.Log(transform.name + " died");
        gameObject.SetActive(false);
    }
}
