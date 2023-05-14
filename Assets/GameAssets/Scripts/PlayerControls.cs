using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 5;
    private float gravityValue = -9.81f;
    float V;
    float X;
    Animator Anim;
    public Joystick TheJoystick;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        InputMan();
        MoveMan();
        //AnimMan();

    }
    void InputMan()
    {
        X = TheJoystick.Direction.x;
        V = TheJoystick.Direction.y;
    }
    void AnimMan()
    {
        if (Anim == null || Anim != null && !Anim.gameObject.activeSelf)
        {
            Anim = GetComponentInChildren<Animator>();
        }
        Anim.SetFloat("V", Vector3.SqrMagnitude(move));
    }
    Vector3 move;
    void MoveMan()
    {
        groundedPlayer = controller.isGrounded;
        move = new Vector3(X, 0, V);
        move.Normalize();

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
