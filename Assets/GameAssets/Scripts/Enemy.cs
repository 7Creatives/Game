using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public GameObject EnemyModel;
    public GameObject Cash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void spawncash()
    {
        GameObject Go = Instantiate(Cash,transform.position+new Vector3(0,1,0),Quaternion.identity);
    }
}
