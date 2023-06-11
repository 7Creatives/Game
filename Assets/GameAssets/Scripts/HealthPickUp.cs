using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    public GameObject Tr;
    // Update is called once per frame
    void Update()
    {
        Tr.transform.Rotate(new Vector3(0, GameManager.Instance.GamePlayVariables_.degreesPerSecond_HealthpicUp, 0) * Time.deltaTime);
    }
}
