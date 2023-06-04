using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon_Collision : MonoBehaviour
{
    public GameObject Player;
    public static int HitCount = 0;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.GetComponent<PlayerCombat>() != null)
        {
            Debug.Log("1st Hit");
            if(HitCount == 0)
            {
                StartCoroutine(Delay(1,1));
                HitCount = 1;
            } 
        }  
    }

    IEnumerator Delay(float time, float Damage)
    {
        yield return new WaitForSeconds(time);
        Player.GetComponent<PLayerHealth>().TakeDamage(Damage);
    }

    private void OnTriggerExit(Collider other) 
    {
        
        if(other.gameObject.GetComponent<PlayerCombat>() != null)
        {
            Debug.Log("finished Attack");
            if(HitCount == 1)
            {
                HitCount = 0;
            } 
        }  
    }
}
