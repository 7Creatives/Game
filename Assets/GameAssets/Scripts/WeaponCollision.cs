using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<EnemyCollisionHandler>() != null)
        {
            Debug.Log("Hit");
            // reduce EnemyHealth
            enemyHealth.TakeDamage(25);
        }
    }
}
