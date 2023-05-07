using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(hit.gameObject.GetComponentInChildren<CashSpawner>() != null)
        {
            Debug.Log("Invest");
            hit.gameObject.GetComponentInParent<BuildingHandler>().Unlocker(GameManager.Instance.GamePlayVariables_.AmountToDecrease);
            GameManager.Instance.CashManager_.DecreaseCash(Mathf.FloorToInt(GameManager.Instance.GamePlayVariables_.AmountToDecrease));
        }

        if(hit.gameObject.GetComponentInParent<Cash>() != null)
        {

            // AddTo The Ui
            GameManager.Instance.CashManager_.IncreaseCash(Mathf.FloorToInt(GameManager.Instance.GamePlayVariables_.AmountToIncrease));
            Debug.Log("profits");
            GameObject Go = hit.gameObject.GetComponentInChildren<Cash>().gameObject;
            //DestroyCash
            Destroy(Go);

        }
    }
}
