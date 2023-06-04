using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PLayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    public float currentHealth = 20;
    public bool isPlayerDead =false;
    public Vector3 offset;

    public Image healthUI_Green;
    public Image healthUI_Red;
    public Image healthUI_Orange;
    public float HealthUI_rate = 5f;

    public void start()
    {
        SetUp();
    }

    public void SetUp()
    {
        healthUI_Orange.fillAmount = currentHealth/MaxHealth;
        healthUI_Red.fillAmount = currentHealth/MaxHealth;
        healthUI_Orange.fillAmount = currentHealth/MaxHealth;
    }

    public void IncreaseHealth(float Health)
    {
        currentHealth = currentHealth + Health;
        healthUI_Orange.fillAmount = currentHealth/MaxHealth;
        healthUI_Red.fillAmount = currentHealth/MaxHealth;
        healthUI_Orange.gameObject.SetActive(true);
        healthUI_Red.gameObject.SetActive(false);

        if(currentHealth >= MaxHealth)
        { 
            currentHealth = MaxHealth;
        }
    }

    public void TakeDamage(float Damage)
    {
        currentHealth = currentHealth - Damage;
        healthUI_Green.fillAmount = currentHealth/MaxHealth;
        healthUI_Orange.fillAmount = currentHealth/MaxHealth;
        healthUI_Orange.gameObject.SetActive(false);
        healthUI_Red.gameObject.SetActive(true);

        if(currentHealth <= 0 && isPlayerDead == false)
        {
            isPlayerDead = true;
            if(isPlayerDead)
            {
                currentHealth = 0;
                //Game over
                GetComponentInChildren<Animator>().enabled = false;
                //restartLevel
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Health bar movement
        healthUI_Green.fillAmount = Mathf.Lerp(healthUI_Green.fillAmount,currentHealth/MaxHealth,HealthUI_rate * Time.deltaTime);
        healthUI_Red.fillAmount = Mathf.Lerp(healthUI_Red.fillAmount,currentHealth/MaxHealth,HealthUI_rate * Time.deltaTime);

    }
}
