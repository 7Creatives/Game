using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Animator Anim;
    public GameObject Model;

    private void Update() 
    {
        Model.transform.position = transform.position;
    }
}
