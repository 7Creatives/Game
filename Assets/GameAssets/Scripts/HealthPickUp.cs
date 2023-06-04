using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, GameManager.Instance.GamePlayVariables_.degreesPerSecond_HealthpicUp, 0) * Time.deltaTime);
    }
}
