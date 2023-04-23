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
    public float gravityScale = 1f;
    public float MinJumpHeight = 2f;
    public float LowerJumpHeight = 2f;
    public Animator Animator;
    public float initialSpeed;

    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        initialSpeed = playerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded = charController.isGrounded;
        if(IsGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float y =Input.GetAxis("Horizontal");
        float x = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(y,0,x);
        charController.Move(movement*Time.deltaTime*playerSpeed);

        if (movement != Vector3.zero)
        {
            //gameObject.transform.forward = movement;
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            Animator.SetFloat("Movement",0.5f);
        }
        else
        {
            Animator.SetFloat("Movement",0f);
        }

        if(Input.GetButton("Fire3")&& IsGrounded)
        {
            if (movement != Vector3.zero)
            {
                Animator.SetFloat("Movement",1f);
                playerSpeed =  6;
            }   
        }
        else
        {
            playerSpeed = initialSpeed;
        }
        
        // Jump
        if(Input.GetButtonDown("Jump")&& IsGrounded)
        {
            //Jump action
            Animator.SetTrigger("Jump");
        }
        else
        {
            if(playerVelocity.y > MinJumpHeight )
            {
                gravityScale = 3f;
            }
            else if(playerVelocity.y <= .5f )
            {
                gravityScale = 1f;
            }
        }   
             

        playerVelocity.y += gravityValue*gravityScale * Time.deltaTime;
        charController.Move(playerVelocity*Time.deltaTime);
    }

    public void JumpAction()
    {
        playerVelocity.y += Mathf.Sqrt(jumpHeight* -3.0f*(gravityValue* gravityScale));
    }
}
