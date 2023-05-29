using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<EnemyCollisionHandler>() != null)
        {
            Debug.Log("Hit");
            GetComponentInParent<CollisionHandler>().enemy.GetComponent<EnemyHealth>().TakeDamage(25);
            
        }
    }
}
