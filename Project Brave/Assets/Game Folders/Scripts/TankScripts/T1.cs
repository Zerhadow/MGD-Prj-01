using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class T1 : MonoBehaviour
{
    public GameObject t1InfoObj;
    public TankBase t1Info;
    private TMP_Text t1PowerInfoText;
    private TMP_Text t1FragmentsInfoText;

    public void T1UnitPage() 
    {
        t1InfoObj.SetActive(true);
    }

    public void T1UpdateStats() {
    }
}
