using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject Enemy;
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(hit.gameObject.GetComponentInChildren<CashSpawner>() != null)
        {
            if(GameManager.Instance.CashManager_.Amount<=0)
            return;
            Debug.Log("Invest");
            hit.gameObject.GetComponentInParent<BuildingHandler>().Unlocker(GameManager.Instance.GamePlayVariables_.AmountToDecrease);
            GameManager.Instance.CashManager_.DecreaseCash(Mathf.FloorToInt(GameManager.Instance.GamePlayVariables_.AmountToDecrease));

            //Unlock building
            hit.gameObject.GetComponentInParent<BulidingManager>().UnlockBuilding();

        }

        if(hit.gameObject.GetComponentInParent<Cash>() != null)
        {

            

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

        // if(other.gameObject.GetComponent<EnemyCollisionHandler>() != null)
        // {
        //     Debug.Log("Hit");
        //     // reduce EnemyHealth
        // }
    }

    private void Update()
    {
        float Dist = Vector3.Distance(transform.position,Enemy.transform.position);
        if(Dist < 2)
        {
            Enemy.transform.position = transform.position + new Vector3(0,0,1.5f);
            Enemy.transform.LookAt(this.gameObject.transform);
        }
    }
}
