using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject enemy;
    private Vector3 Offset;
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(hit.gameObject.GetComponentInChildren<CashSpawner>() != null)
        {
            Debug.Log("Invest");
            if(GameManager.Instance.CashManager_.Amount>0)
            {
                GameManager.Instance.CashManager_.DecreaseCash(Mathf.FloorToInt(GameManager.Instance.GamePlayVariables_.AmountToDecrease));
                hit.gameObject.GetComponentInParent<BuildingHandler>().Unlocker(GameManager.Instance.GamePlayVariables_.AmountToDecrease);
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
    }

    private void Update() 
    {
        float Dist = Vector3.Distance(transform.position,enemy.transform.position);
        if(Dist<1.5f)
        {
            if(enemy.GetComponentInChildren<EnemyHealth>().isEnemyDead)
            {

            }
            else
            {
                //stop
                transform.position = enemy.transform.position + enemy.transform.InverseTransformDirection(0,0,1.2f);
            } 
        }
    }
}
