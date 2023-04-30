using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildingHandler : MonoBehaviour
{
    public BuildingDetails _buildingDetails;
    // Start is called before the first frame update
    void Start()
    {
        _buildingDetails.cashToUnlock.text = "Ksh. " + _buildingDetails.CashToUnlock.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            UnlockBuilding(10);
            if(_buildingDetails.fillmeter>=_buildingDetails.CashToUnlock)
            {

                _buildingDetails.building.SetActive(true);
                GetComponentInChildren<CashSpawner>().spawncash();
            }
        }
        _buildingDetails.UnlockImage.fillAmount = (_buildingDetails.fillmeter/_buildingDetails.CashToUnlock);
    }

    public void UnlockBuilding(float Amount)
    {
        _buildingDetails.fillmeter = _buildingDetails.fillmeter + Amount;
       
    }
}

[System.Serializable]
public class BuildingDetails
{
    public GameObject building;
    public int CashToUnlock;
    public TMP_Text cashToUnlock;
    public Image UnlockImage; 
    public float UnlockRate = 10;
    public float fillmeter;
    public bool canUnlock;
}
