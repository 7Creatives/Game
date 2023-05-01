using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public CashManager CashManager_;
    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if(hit.gameObject.GetComponentInChildren<CashSpawner>() != null)
        {
            Debug.Log("Invest");
            hit.gameObject.GetComponentInParent<BuildingHandler>().UnlockBuilding(10);
        }

        if(hit.gameObject.GetComponentInChildren<Cash>() != null)
        {
            //DestroyCash
            
            // AddTo The Ui
            CashManager_.IncreaseCash(1);
            Debug.Log("profits");

        }
    }
}
