using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject enemy;
    public LayerMask layerMask;
    public bool isEnemy;
    private void Start() 
    {  

    }   

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(hit.gameObject.GetComponentInChildren<CashSpawner>() != null)
        {
            Debug.Log("Invest");
            if(GameManager.Instance.CashManager_.Amount> 0)
            {
                GameManager.Instance.CashManager_.DecreaseCash(Mathf.FloorToInt(GameManager.Instance.GamePlayVariables_.AmountToDecrease));
                hit.gameObject.GetComponentInParent<BuildingHandler>().Unlocker(GameManager.Instance.GamePlayVariables_.AmountToDecrease);
            }
            else
            {

            }
            //Unlock building
            hit.gameObject.GetComponentInParent<BulidingManager>().UnlockBuilding();

        }
       
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.GetComponentInParent<Cash>() != null)
        {
            //// AddTo The Ui
            GameManager.Instance.CashManager_.IncreaseCash(Mathf.FloorToInt(GameManager.Instance.GamePlayVariables_.AmountToIncrease));
            Debug.Log("profits");
            GameObject Go = other.gameObject.GetComponentInChildren<Cash>().gameObject;
            //DestroyCash
            Destroy(Go);
        }
        else if(other.gameObject.GetComponent<HealthPickUp>() != null)
        {
            Debug.Log("Increase Health");
            if( GetComponent<PLayerHealth>().currentHealth < 100)
            {
                GetComponent<PLayerHealth>().IncreaseHealth(25);
                Destroy(other.gameObject);
            }
        }
    }

    private void Update() 
    {
        if(enemy != null)
        {
            if(enemy.GetComponent<EnemyHealth>().isEnemyDead)
            {
                enemy = null;
                GetComponentInChildren<WeaponCollision>().TheEnemy = null;
            }
        }
        else
        {   

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitData;
            if(Physics.Raycast(ray,out hitData,4,layerMask))
            {
                Debug.Log("Hit Enemy"+ name);
                // that is the enemy
                enemy = hitData.transform.GetComponentInParent<EnemyFollowing>().gameObject;
                GetComponentInChildren<WeaponCollision>().TheEnemy = enemy ;
            }
            Debug.DrawRay(ray.origin + new Vector3(0,1,0), ray.direction, Color.red);
        }
        
    }
}
