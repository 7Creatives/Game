using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController charController;
    private Vector3 playerVelocity;
    public bool IsGrounded;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = charController.isGrounded;
        if(IsGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        charController.Move(movement*Time.deltaTime*playerSpeed);

        if (movement != Vector3.zero)
        {
            gameObject.transform.forward = movement;
            Animator.SetFloat("Movement",0.5f);
        }
        else
        {
            Animator.SetFloat("Movement",0f);
        }

        // Jump
        if(Input.GetButtonDown("Jump")&& IsGrounded)
        {
            //Jump action
            Animator.SetBool("Jump",true);
        }
        else{
            Animator.SetBool("Jump",false);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        charController.Move(playerVelocity*Time.deltaTime);
    }

    public void JumpAction()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight* -3.0f*gravityValue);
    }
}
