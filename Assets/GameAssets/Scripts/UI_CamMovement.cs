using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CamMovement : MonoBehaviour
{
    public Transform objectToOrbit;
    public float speed;

   
    // Update is called once per frame
  
    void Update()
    {
        transform.RotateAround(objectToOrbit.position, Vector3.up, speed* Time.deltaTime);
    }
}
