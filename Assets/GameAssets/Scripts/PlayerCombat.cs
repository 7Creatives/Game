using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator Anim;
    public bool IsFighting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(!IsFighting)
            {
                //fight 
                Anim.SetLayerWeight(1,1);
                Anim.SetTrigger("Attack");
            }
            IsFighting = true;
          
        }
        else
        {
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
