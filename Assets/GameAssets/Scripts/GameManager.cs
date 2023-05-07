using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get;private set;} 
    public CashManager CashManager_;
    public GamePlayVariables GamePlayVariables_;
    public void Awake()
    {   
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }
}
