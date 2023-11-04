using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController charController;

    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool shitIfPressed = Input.GetKey(KeyCode.LeftShift);
        float deltaX = shitIfPressed ? Input.GetAxis("Horizontal") * speed * 2 : Input.GetAxis("Horizontal") * speed;
        float deltaZ = shitIfPressed ? Input.GetAxis("Vertical") * speed * 2 : Input.GetAxis("Vertical") * speed * 2;
        float dt = Time.deltaTime;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, shitIfPressed ? speed * 2 : speed);
        movement.y = gravity;
        movement *= dt;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);
    }
}
