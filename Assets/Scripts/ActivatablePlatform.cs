using UnityEngine;

public class ActivatablePlatform : MonoBehaviour
{
    public bool isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the specified tag (e.g., "Cube")
        if (other.CompareTag("Cube"))
        {
            // Activate the platform when the cube enters the trigger zone
            ActivatePlatform();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Check if the object inside the trigger zone is the specified cube
        if (other.CompareTag("Cube"))
        {
            // Perform continuous actions while the cube stays inside the trigger zone
            // You can add additional logic here if needed
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the exiting object has the specified tag (e.g., "Cube")
        if (other.CompareTag("Cube"))
        {
            // Deactivate the platform when the cube exits the trigger zone
            DeactivatePlatform();
        }
    }

    private void ActivatePlatform()
    {
        if (!isActivated)
        {
            // Implement the logic to activate the platform
            Debug.Log("Platform Activated");
            isActivated = true;
        }
    }

    private void DeactivatePlatform()
    {
        if (isActivated)
        {
            // Implement the logic to deactivate the platform
            Debug.Log("Platform Deactivated");
            isActivated = false;
        }
    }

    public bool IsActivated()
    {
        return isActivated;
    }
}
