using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementHandler : MonoBehaviour
{
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public float gravityMultiplier = 2f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float MaxlookXLimit = 60.0f;
    public float MinlookXLimit = 5.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;
    public Vector3 Offset;
    
    public Animator Animator;

    [HideInInspector]
    public bool canMove = true;

    public float initialSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
        initialSpeed = speed;
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);
            float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            //Animator.SetFloat("Movement",0.5f);

            if (Input.GetButton("Jump") && canMove)
            {
                Animator.SetTrigger("Jump");
            }

            if(moveDirection !=Vector3.zero)
            {
                Animator.SetFloat("Movement",0.5f);
                if(Input.GetButton("Fire3"))
                {
                    Animator.SetFloat("Movement",1f);
                    speed =  6; 
                }
                else
                {
                    speed = initialSpeed;
                }
            }
            else
            {
                Animator.SetFloat("Movement",0f);
            }
        }
        
        

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * gravityMultiplier * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
            rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotation.x = Mathf.Clamp(rotation.x, MinlookXLimit, MaxlookXLimit);
            playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(0, rotation.y);
            
        }
    } 


    public void JumpAction()
    {
        moveDirection.y = jumpSpeed;
    }

}
