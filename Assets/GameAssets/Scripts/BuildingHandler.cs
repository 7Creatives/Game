using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingHandler : MonoBehaviour
{
    public float CashAmountToUnlock;
    public TMP_Text cashToUnlock;
    public Image UnlockImage; 
    public float fillmeter;


    private void Start() 
    {
        // show remaining amount
        cashToUnlock.text = "Ksh. " + fillmeter.ToString() +"/" + CashAmountToUnlock.ToString(); 
    }

    private void Update() 
    {
        UnlockImage.fillAmount = (fillmeter/CashAmountToUnlock);
        if(fillmeter > CashAmountToUnlock)
        {
            fillmeter = CashAmountToUnlock;
        }
    }

    public void Unlocker(float Amount)
    {
        fillmeter = fillmeter + Amount; 
        cashToUnlock.text = "Ksh. " + fillmeter.ToString() +"/" + CashAmountToUnlock.ToString(); 
    }
}
