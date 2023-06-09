using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    public float currentHealth = 20;
    public bool isEnemyDead =false;

    public Image EM_healthUI_Green;
    public Image EM_healthUI_Red;
    public float HealthUI_rate = 5f;
    public GameObject Canvas_;

    public void start()
    {
        EM_healthUI_Green.fillAmount = currentHealth/MaxHealth;
        EM_healthUI_Red.fillAmount = currentHealth/MaxHealth;
    }

    public void TakeDamage(float Damage)
    {
        currentHealth = currentHealth - Damage;
        EM_healthUI_Green.fillAmount = currentHealth/MaxHealth;

        if(currentHealth <= 0 && isEnemyDead == false)
        {
            isEnemyDead = true;
            //GetComponentInParent<EnemyController>().Enemies.Remove(this.gameObject);
            Destroy(Canvas_);
            GetComponentInParent<Enemy>().spawncash();
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        EM_healthUI_Red.fillAmount = Mathf.Lerp(EM_healthUI_Red.fillAmount,currentHealth/MaxHealth,HealthUI_rate * Time.deltaTime);
        
    }
}
