using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BulidingManager : MonoBehaviour
{
    // building Deatils
    public Buildings[] _buildings;
    [System.Serializable]
    public class Buildings
    {
        public string Buildingname = "buildingName" ;
        public GameObject _Building;
        public bool canUnlock;
        public bool canTax;
        public float ProfitRate;
        public List<GameObject> Cash = new List<GameObject>();
        public BuildingHandler buildingHandler;
    }

    float ProfitCollectedTimeStamp;
    float cashTimer;

    public void UnlockBuilding()
    {
        for(int i = 0; i < _buildings.Length;i++)
        {

            if(_buildings[i].buildingHandler.fillmeter >= _buildings[i].buildingHandler.CashAmountToUnlock)
            {
                _buildings[i].canUnlock = true;
                //unloocking
                if(_buildings[i].canUnlock)
                {
                    _buildings[i].buildingHandler.GetComponentInChildren<CashSpawner>().gameObject.GetComponent<Collider>().enabled = false;
                    _buildings[i].buildingHandler.Ui.SetActive(false);
                    _buildings[i].canTax = true;
                    _buildings[i]._Building.SetActive(true); 
                   if(_buildings[i].canTax)
                   {
                        GenerateCash();
                   }
                }
                else
                {
                    _buildings[i]._Building.SetActive(false);
                }
            }
            else
            {
                _buildings[i]._Building.SetActive(false);
                _buildings[i].canUnlock = false;
                _buildings[i].canTax = false;
            }
        }
    }


    public void GenerateCash()
    {
        //generate cash
        for(int i = 0; i<_buildings.Length;i++)
        {
            if (cashTimer < Time.time)
            {
                cashTimer = Time.time + _buildings[i].ProfitRate;

                if(ProfitCollectedTimeStamp < Time.time)
                {
                    _buildings[i].buildingHandler.GetComponentInChildren<CashSpawner>().spawncash();
                }
            }
        }
        
    }
}