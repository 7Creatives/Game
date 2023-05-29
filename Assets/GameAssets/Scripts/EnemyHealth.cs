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
    
    public GameObject Cashitem;
    public Transform cashparent;
    public float CashToSpawn;  
    public GameObject Canvas;

    public void start()
    {
        
    }

    public void TakeDamage(float Damage)
    {
        currentHealth = currentHealth - Damage;
        EM_healthUI_Green.fillAmount = currentHealth/MaxHealth;

        if(currentHealth <= 0 && isEnemyDead == false)
        {
            isEnemyDead = true;
            if(isEnemyDead){
                //spawn cash
                for (int i = 0; i < CashToSpawn; i++)
                {
                    GameObject Go = Instantiate(Cashitem,cashparent);
                    Go.transform.position = transform.position + new Vector3(0, .5f, 0);
                }   
               
            }
            //GetComponentInParent<EnemyController>().Enemies.Remove(this.gameObject);
           GetComponent<Enemy>().Anim.enabled = false;
           GetComponentInChildren<Rigidbody>().isKinematic = true;
           GetComponentInChildren<Collider>().enabled = false;
           Canvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        EM_healthUI_Red.fillAmount = Mathf.Lerp(EM_healthUI_Red.fillAmount,currentHealth/MaxHealth,HealthUI_rate * Time.deltaTime);
    }
}
