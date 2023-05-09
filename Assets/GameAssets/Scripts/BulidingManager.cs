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
        public bool canUnlock;
        public bool canTax;
        public List<GameObject> Cash = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        UnlockBuilding("Shop",true,true);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyCash()
    {

    }

    public void UnlockBuilding(string _Buildingname,bool isUnlockable,bool isTaxable)
    {
        for(int i = 0; i < _buildings.Length;i++)
        {
            
            if(_buildings[i].Buildingname == _Buildingname)
            {    
                _buildings[i].canUnlock = isUnlockable;
                _buildings[i].canTax = isTaxable;
                if(isUnlockable)
                {
                    _buildings[i]._Building.SetActive(true);
                    if(isTaxable)
                    {
                        //start taxing
                    }
                }
                else
                {
                    _buildings[i]._Building.SetActive(false);
                }
               
            }
            else
            {
                isUnlockable =false;
                isTaxable = false;
            }
        }
    }

}

