using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAnimation : MonoBehaviour
{
   public void Jump()
   {
        GetComponentInParent<PlayerMovement>().JumpAction();
   }
}
