using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingHandler : MonoBehaviour
{
   
    public float ProfitRate = 10;
    public GameObject building;
    public int CashToUnlock;
    public TMP_Text cashToUnlock;
    public Image UnlockImage; 
    public float fillmeter;
    // Start is called before the first frame update
    void Start()
    {
        cashToUnlock.text = "Ksh. " + CashToUnlock.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnlockBuilding(float Amount)
    {
        fillmeter = fillmeter + Amount; 
        UnlockImage.fillAmount = (fillmeter/CashToUnlock);
    }

    public void SpawnCash()
    {
        GetComponentInChildren<CashSpawner>().spawncash();
    }
}
