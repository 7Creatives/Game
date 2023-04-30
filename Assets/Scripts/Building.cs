using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    public GameObject building;

    public int CashToUnlock;
    public TMP_Text cashToUnlock;
    public Image UnlockImage; 
    public float UnlockRate = 10;
    public float fillmeter;
    public bool canUnlock;
    // Start is called before the first frame update
    void Start()
    {
        cashToUnlock.text = "Ksh. " + CashToUnlock.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            UnlockBuilding(10);
            if(fillmeter>=CashToUnlock)
            {
                //unlock house
                building.SetActive(true);
                
            }
        }
        UnlockImage.fillAmount = (fillmeter/CashToUnlock);
    }

    public void UnlockBuilding(float Amount)
    {
        fillmeter = fillmeter + Amount;
       
    }
}
