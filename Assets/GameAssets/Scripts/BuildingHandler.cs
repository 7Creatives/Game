using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingHandler : MonoBehaviour
{
    public BuildingDetails _buildingDetails;
    float cashTimer;
    public float ProfitRate = 10;
    public float ProfitCollectedTimeStamp;
    // Start is called before the first frame update
    void Start()
    {
        _buildingDetails.cashToUnlock.text = "Ksh. " + _buildingDetails.CashToUnlock.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(_buildingDetails.fillmeter>=_buildingDetails.CashToUnlock)
        {

            _buildingDetails.building.SetActive(true);
            Profits();

        }
        _buildingDetails.UnlockImage.fillAmount = (_buildingDetails.fillmeter/_buildingDetails.CashToUnlock);
    }

    public void UnlockBuilding(float Amount)
    {
        _buildingDetails.fillmeter = _buildingDetails.fillmeter + Amount;
       
    }

    public void Profits()
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

    public void SpawnCash()
    {
        GetComponentInChildren<CashSpawner>().spawncash();
    }
}

[System.Serializable]
public class BuildingDetails
{
    public GameObject building;
    public int CashToUnlock;
    public TMP_Text cashToUnlock;
    public Image UnlockImage; 
    public float fillmeter;
    public bool canUnlock;
}
