using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulidingManager : MonoBehaviour
{
    public Buildings[] _buildings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyCash()
    {

    }
}

[System.Serializable]
public class Buildings
{
    public string Buildingname;
    public GameObject Building;
    public List<GameObject> Cash = new List<GameObject>();
}
