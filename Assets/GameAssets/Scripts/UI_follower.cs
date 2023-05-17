using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_follower : MonoBehaviour
{
     public Vector3 Offset;
     public Transform Point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(Point.transform.position + Offset); 
    }
}
