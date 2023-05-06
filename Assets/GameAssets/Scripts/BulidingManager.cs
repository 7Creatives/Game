using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulidingManager : MonoBehaviour
{
    public Buildings[] _buildings;
    [System.Serializable]
    public class Buildings
    {
        public string Buildingname = "buildingName" ;
        public GameObject _Building;
        float ProfitCollectedTimeStamp;
        float cashTimer;
        public bool canUnlock;
        public bool IsTaxable;
        public List<GameObject> Cash = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        UnlockBuilding("Shop");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyCash()
    {

    }
    public void AutoProfits()
    {
        
        // if (cashTimer < Time.time)
        // {
        //     cashTimer = Time.time + ProfitRate;

        //     if(ProfitCollectedTimeStamp < Time.time)
        //     {
        //         SpawnCash();
        //     }
            
        // }
    }

    public void UnlockBuilding(string _Buildingname)
    {
        for(int i = 0; i < _buildings.Length;i++)
        {
            if(_buildings[i].Buildingname == _Buildingname)
            {
                _buildings[i].canUnlock = true;
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
                _buildings[i].canUnlock = false;
            }
           
        }
    }

    
}

