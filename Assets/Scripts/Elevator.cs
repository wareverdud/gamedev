using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour
{
    [SerializeField] private float floorHeight = 10.5f;
    [SerializeField] private float movementSpeed = 1f;
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
    }
}
