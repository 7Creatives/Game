using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingHandler : MonoBehaviour
{
    public float ProfitRate = 10;
    public GameObject building;
    public float CashAmountToUnlock;
    public TMP_Text cashToUnlock;
    public Image UnlockImage; 
    public float fillmeter;

    float ProfitCollectedTimeStamp;
    float cashTimer;
    // Start is called before the first frame update
    void Start()
    {
        cashToUnlock.text = "Ksh. " + CashAmountToUnlock.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Unlocker(float Amount)
    {
        fillmeter = fillmeter + Amount; 
        UnlockImage.fillAmount = (fillmeter/CashAmountToUnlock);
    }
    
    public void SpawnCash()
    {
        GetComponentInChildren<CashSpawner>().spawncash();
    }

    public void GetProfits()
    {  
        if (cashTimer < Time.time)
        {
            cashTimer = Time.time + ProfitRate;

            if(ProfitCollectedTimeStamp < Time.time)
            {
                SpawnCash();
                
            }
            
        }
    }
}
