using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CamMovement : MonoBehaviour
{
    public Transform objectToOrbit;
    public float speed;

   private void OnEnable() 
   {
        DontDestroyOnLoad(gameObject);
        Move();
   }
    // Update is called once per frame
  
    void FixedUpdate()
    {
        
       Move();
    }

    public void Move()
    {
        transform.RotateAround(objectToOrbit.position, Vector3.up, speed* Time.deltaTime);
    }
}
