using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private CharacterController charController;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public float jumpForce;

    private Camera cam;

    void Start()
    {
        charController = GetComponent<CharacterController>();

        cam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Vector3 impulse = new Vector3(0f, 10f, 0f);
            // rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            charController.Move(impulse * Time.deltaTime);
            // rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }   
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "^");
    }
}
