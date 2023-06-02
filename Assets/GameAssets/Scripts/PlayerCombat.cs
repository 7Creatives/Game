using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator Anim;
    public bool IsFighting;
    public bool isFight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            isFight =true;
            if(!IsFighting)
            {
                //fight 
                Anim.SetLayerWeight(1,1);
                Anim.SetTrigger("Attack");
                if(GetComponentInParent<CollisionHandler>().enemy != null)
                {
                    GetComponentInParent<CollisionHandler>().enemy.GetComponentInChildren<EnemyCombat>().fight = true;
                }
               
            }
            IsFighting = true;
          
        }
        else
        {
            isFight =false;
            if(IsFighting)
            {
                IsFighting = false;
                //Anim.SetLayerWeight(1,0);
                //Anim.SetLayerWeight(0,1);
                //Anim.SetFloat("Movement",0f);
            }
        }

          
    }
}
