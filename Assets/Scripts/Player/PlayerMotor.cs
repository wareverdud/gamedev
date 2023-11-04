using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    private bool sprinting = false;
    private float speed = 5f;

    public float slowSpeed = 5f;
    public float fastSpeed = 10f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        if (sprinting)
        {
            speed = fastSpeed;
        } else
        {
            speed = slowSpeed;
        }
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0f)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
        }
    }

    public void SprintEnable()
    {
        sprinting = true;
    }

    public void SprintDisable()
    {
        sprinting = false;
    }
}
