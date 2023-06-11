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

    public GameObject Ui;


    private void Start() 
    {
        // show remaining amount
        cashToUnlock.text = "$ " + fillmeter.ToString() +"/" + CashAmountToUnlock.ToString(); 
    }

    private void Update() 
    {
        UnlockImage.fillAmount = (fillmeter/CashAmountToUnlock);
        if(fillmeter >= CashAmountToUnlock)
        {
            fillmeter = CashAmountToUnlock;
        }
        cashToUnlock.text = "$ " + fillmeter.ToString() +"/" + CashAmountToUnlock.ToString(); 
    }

    public void Unlocker(float Amount)
    {
        fillmeter = fillmeter + Amount; 
      
    }
}
