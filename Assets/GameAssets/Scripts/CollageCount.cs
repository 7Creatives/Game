using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollageCount : MonoBehaviour
{
    public TMP_Text CollageCounter;
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i<GameManager.Instance.BulidingManager_._buildings.Length;i++)
        {
            CollageCounter.text = GetUnlockedCollages().ToString() + "/" + GameManager.Instance.BulidingManager_._buildings.Length.ToString();
        }   
    }

    public int GetUnlockedCollages(){
        int Count = 0;
        for(int i = 0;i<GameManager.Instance.BulidingManager_._buildings.Length;i++)
        {
           if(GameManager.Instance.BulidingManager_._buildings[i].canUnlock == true)
           {
                Count++;
           }
        }  
        counter = Count;
        return Count;
    }

    public int GetTotalCollages()
    {
        int totalcollages =  GameManager.Instance.BulidingManager_._buildings.Length;
        return  totalcollages;
    }
}
