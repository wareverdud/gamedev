using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.WalkingActions walking;

    private PlayerMotor motor;
    private PlayerLook look;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        walking = playerInput.Walking;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        walking.Jump.performed += ctx => motor.Jump();
        walking.Sprint.started += ctx => motor.SprintEnable();
        walking.Sprint.canceled += ctx => motor.SprintDisable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // tell the playermotor to move using the value from our movement action
        motor.ProcessMove(walking.Movement.ReadValue<Vector2>());
        
    }

    void LateUpdate()
    {
        // tell the playermotor to move using the value from our movement action
        look.ProcessLook(walking.Look.ReadValue<Vector2>());

    }

    private void OnEnable()
    {
        walking.Enable();
    }

    private void OnDisable()
    {
        walking.Disable();
    }
}
