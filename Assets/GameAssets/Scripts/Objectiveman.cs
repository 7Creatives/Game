using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectiveman : MonoBehaviour
{
    [System.Serializable]
    public class Objectives
    {
        public bool IsComplete;
        public GameObject Complete;
        public GameObject InComplete;
    }

    public Objectives objective_1;
    public Objectives objective_2;

    bool isobjective_Finished;
    bool isobjective2_Finished;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(checkifObj_Complete())
        {
            obj1_Complete();
        }
        else if(checkifObj2_Complete())
        {
            obj2_Complete();
        }
        else
        {
            obj1_InComplete();
            obj2_InComplete();
        }
        
    }

    public bool checkifObj_Complete()
    {
        if(GameManager.Instance.EnemyCount_.EnemyDeathCount() >= GameManager.Instance.EnemyCount_.GetTotalEnemies())
        {
            return true;
        }

        return false;
    }

    public bool checkifObj2_Complete()
    {
        if(GameManager.Instance.CollageCount_.GetUnlockedCollages() >= GameManager.Instance.CollageCount_.GetTotalCollages())
        {
            return true;
        }

        return false;
    }

    public void obj1_Complete()
    {
        objective_1.IsComplete = true;
        objective_1.Complete.SetActive(objective_1.IsComplete);
        objective_1.InComplete.SetActive(!objective_1.IsComplete);
    }

   

    public void obj1_InComplete()
    {
        objective_1.IsComplete = false;
        objective_1.Complete.SetActive(objective_1.IsComplete);
        objective_1.InComplete.SetActive(!objective_1.IsComplete);
    }

     public void obj2_Complete()
    {
        objective_2.IsComplete = true;
        objective_2.Complete.SetActive(objective_2.IsComplete);
        objective_2.InComplete.SetActive(!objective_2.IsComplete);
    }

    public void obj2_InComplete()
    {
        objective_2.IsComplete = false;
        objective_2.Complete.SetActive(objective_2.IsComplete);
        objective_2.InComplete.SetActive(!objective_2.IsComplete);
    }
}
