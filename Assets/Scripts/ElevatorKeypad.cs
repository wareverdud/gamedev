using UnityEngine;
using TMPro;

public class ElevatorKeypad : MonoBehaviour
{
    [SerializeField] private Elevator elevator;
    [SerializeField] private TextMeshProUGUI interactionText;
    private bool keypadActive = false;

    private void Start()
    {
        // Ensure the TextMeshProUGUI component is initially hidden
        interactionText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keypadActive = true;
            // Display a message to inform the player that they can interact with the keypad
            interactionText.text = "Press '1', '2', or '3' to select a floor.";
            interactionText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            keypadActive = false;
            // Hide the interaction message when the player moves away from the keypad
            interactionText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        // Check for player input to interact with the keypad
        if (keypadActive)
        {
            Interact();
        }
    }

    private void Interact()
    {
        // Check if the elevator is not null
        if (elevator != null)
        {
            // Check for numeric key input
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                // Move the elevator to the first floor
                elevator.MoveToFloor(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                // Move the elevator to the second floor
                elevator.MoveToFloor(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                // Move the elevator to the third floor
                elevator.MoveToFloor(3);
            }
            // Add more conditions for additional floors as needed
        }
    }
}
