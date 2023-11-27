using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private float forceMagnitude = 5f;
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        // Creating a ray from origin of cam looking forward
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // var to store collision info.
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if (inputManager.walking.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody hitRigidbody = hit.collider.attachedRigidbody;

        // Check if the collided object has a Rigidbody
        if (hitRigidbody != null && !hitRigidbody.isKinematic)
        {
            // Access the normal vector of the collision
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            // Apply force to the Rigidbody based on the normal vector
            hitRigidbody.velocity = pushDir * forceMagnitude;
        }
    }
}
