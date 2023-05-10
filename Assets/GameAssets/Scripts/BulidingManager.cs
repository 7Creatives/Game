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
    // Start is called before the first frame update
    void Start()
    {
        //how much we need to unlock vs how much we have contributed
       
        
    }
    
    public void SpawnCash()
    {
        GetComponentInChildren<CashSpawner>().spawncash();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyCash()
    {

    }

    public void UnlockBuilding(string _Buildingname)
    {
        for(int i = 0; i < _buildings.Length;i++)
        {

            if(_buildings[i].Buildingname == _Buildingname)
            {
                _buildings[i].canUnlock = true;
                //unloocking
                if(_buildings[i].canUnlock)
                {
                   _buildings[i]._Building.SetActive(true); 
                }
                else
                {
                    _buildings[i]._Building.SetActive(false);
                }
            }
            else
            {
                _buildings[i]._Building.SetActive(false);
            }
        }
    }


    public void GenerateCash(bool IsTaxable)
    {
        //generate cash
 
        if (cashTimer < Time.time)
        {
            
            //cashTimer = Time.time + ProfitRate;

            if(ProfitCollectedTimeStamp < Time.time)
            {
                SpawnCash();     
            }
        }
    }
}