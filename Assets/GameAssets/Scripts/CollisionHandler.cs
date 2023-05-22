using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject enemy;
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(hit.gameObject.GetComponentInChildren<CashSpawner>() != null)
        {
            Debug.Log("Invest");
            hit.gameObject.GetComponentInParent<BuildingHandler>().Unlocker(GameManager.Instance.GamePlayVariables_.AmountToDecrease);
            //GameManager.Instance.CashManager_.DecreaseCash(Mathf.FloorToInt(GameManager.Instance.GamePlayVariables_.AmountToDecrease));

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
    }
}
