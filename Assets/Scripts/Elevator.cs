using UnityEngine;
using System.Collections;
using TMPro;

public class Elevator : MonoBehaviour
{
    [SerializeField] private float floorHeight = 10.5f;
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private TextMeshProUGUI messageText;
    private bool isMoving = false;

    public void MoveToFloor(int floorNumber)
    {
        if (!isMoving)
        {
            float targetHeight = (floorNumber - 1) * floorHeight;
            Vector3 targetPosition = new Vector3(transform.position.x, targetHeight, transform.position.z);
            StartCoroutine(MoveElevator(targetPosition));
        }
    }

    IEnumerator MoveElevator(Vector3 targetPosition)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;

        if (Mathf.Approximately(targetPosition.y, 1 * floorHeight))
        {
            StartCoroutine(DisplayMessage("To activate fan, you should open two switches", 5f));
        }
    }

    IEnumerator DisplayMessage(string message, float duration)
    {
        messageText.text = message;
        yield return new WaitForSeconds(duration);
        messageText.text = "";
    }
}
