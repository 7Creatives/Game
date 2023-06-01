using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    public GameObject TheEnemy;
    public static int HitCount = 0;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.GetComponent<EnemyCollisionHandler>() != null)
        {
            if(GetComponentInParent<PlayerCombat>().isFight == true)
            {
                Debug.Log("Hit");

                if(HitCount == 0)
                {
                    HitCount = 1;
                    TheEnemy.GetComponent<EnemyHealth>().TakeDamage(25);
                }   
            }
           
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(GetComponentInParent<PlayerCombat>().isFight ==false)
        {
            if(HitCount == 1)
            {
                HitCount = 0;
            }
        }
    }
}
