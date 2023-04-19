using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Camera;
    public Transform Target;
    public bool IsCustomOffset;
    public Vector3 Offset;
    public float smoothSpeed = 2f;
 

    // Start is called before the first frame update
    void Start()
    {
        if(!IsCustomOffset)
        {
            Offset = Camera.transform.position - Target.position;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Smoothfollow();
    }

    public void Smoothfollow()
    {
        Vector3 targetpos = Target.position + Offset;
        Vector3 Smoothfollow = Vector3.Lerp(Camera.transform.position,targetpos,smoothSpeed);

        Camera.transform.position = Smoothfollow;
        Camera.transform.LookAt(Target);
    }
}
