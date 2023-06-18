using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Objectives;
    private void OnEnable() 
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        GameManager.Instance.CountDowntimer_.pauseTimer();
        GameManager.Instance.MovementHandler_.enabled =false;
        GameManager.Instance.PlayerCombat_.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Continue()
    {
        Time.timeScale = 1;
        Objectives.SetActive(false);
        GameManager.Instance.CountDowntimer_.resumeTimer();
        GameManager.Instance.MovementHandler_.enabled =true;
        GameManager.Instance.MovementHandler_.enabled =true;
    }
}
