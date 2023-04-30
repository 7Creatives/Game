using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashSpawner : MonoBehaviour
{
    public GameObject Cash;
    public Vector3 AvailableSpawnPos;
    public Vector3 Bounds = new Vector3(1, 1, 1);
    public Vector3 Spacing = new Vector3(1, 1, 1);
    public Transform Parent;

    public void spawncash()
    {
        if (AvailableSpawnPos.y > Bounds.y)
        {
            return;
        }
        GameObject Go = Instantiate(Cash,Parent);
        Go.transform.localPosition = AvailableSpawnPos;
        AvailableSpawnPos.x +=Spacing.x;
        if (AvailableSpawnPos.x > Bounds.x)
        {
            AvailableSpawnPos.x = -Bounds.x;
            AvailableSpawnPos.z += Spacing.z;
        }
        
        if (AvailableSpawnPos.z > Bounds.z)
        {
            AvailableSpawnPos.x = -Bounds.x;
            AvailableSpawnPos.z =-Bounds.z;
            AvailableSpawnPos.y +=Spacing.y;
        }
    }

}
