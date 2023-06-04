using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountDowntimer : MonoBehaviour
{
    private bool shouldCount = true;

    public TMP_Text timerText; 
    [SerializeField] private Image uiFillImage;

    public float timeValue = 90;
    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0)
        {
            if(!shouldCount){ return; }

            timeValue -= Time.deltaTime;

            if(timeValue < 90 && timeValue > 60)
            {
               //green
               uiFillImage.color = Color.green;
            }
            else if(timeValue < 60 && timeValue >30 )
            {
                //Orange
                uiFillImage.color = Color.yellow;
            }
            else if(timeValue < 30 && timeValue > 0)
            {
                // Red
                uiFillImage.color = Color.red;
            }

        }
        else
        {
            timeValue = 0;
            //GameOverHandler.instance.EndGame();
            GameManager.Instance.PlayerCombat_.Anim.enabled =false;
        }
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if(timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds); 
        uiFillImage.fillAmount = Mathf.InverseLerp(0,90,timeToDisplay);
    }

    public int EndTimer(){
        shouldCount = false;

        timerText.text = string.Empty;
        uiFillImage.fillAmount = 0;

        return Mathf.FloorToInt(timeValue);
    }

    public int pauseTimer()
    {
        shouldCount = false;

        return Mathf.FloorToInt(timeValue);
    }

    public int resumeTimer()
    {
        shouldCount = false;

        return Mathf.FloorToInt(timeValue);
    }
}
