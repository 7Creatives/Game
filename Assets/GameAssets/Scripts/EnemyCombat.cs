using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator Anim;
    public bool IsFighting;
    public bool fight;
    public float fightTimestamp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fight)
        {
            if(fightTimestamp<Time.time)
            {
                if(!IsFighting)
                {
                    Anim.SetLayerWeight(1,1);
                    Anim.SetTrigger("Attack");
                }
                IsFighting = true;
                fightTimestamp = Time.time+1f;
            }
        }
        else
        {
            if(IsFighting)
            {
                IsFighting =false;
                Anim.SetLayerWeight(1,0);
            }
        }
    }
}
