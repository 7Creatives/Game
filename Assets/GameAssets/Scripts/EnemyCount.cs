using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCount : MonoBehaviour
{
    public TMP_Text Enemy_Count;
    public int DeadEnemyCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i<GameManager.Instance.EnemyManager_.Enemies.Length;i++)
        {
            Enemy_Count.text = EnemyDeathCount().ToString() + "/" + GameManager.Instance.EnemyManager_.Enemies.Length.ToString();
        }
        
    }

    public int EnemyDeathCount()
    {
        int count = 0;
        for(int i = 0;i<GameManager.Instance.EnemyManager_.Enemies.Length;i++)
        {
           if(GameManager.Instance.EnemyManager_.Enemies[i].isEnemyDead == true)
           {
                count++;
           }
        }
        DeadEnemyCount = count;
        return count;
    }
}
