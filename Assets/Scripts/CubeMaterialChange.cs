using UnityEngine;

public class CubeMaterialChange : MonoBehaviour
{
    public Material hitMaterial;
    public Material defaultMaterial;
    public bool isActivated = false;

    public float oscillationSpeed = 1f;
    private float from = 23.46f;
    private float to = 39.34f;

    void Start()
    {
        GetComponent<Renderer>().material = defaultMaterial;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Prop"))
        {
            isActivated = true;
            GetComponent<Renderer>().material = hitMaterial;
        }
    }

    void Move()
    {
        float xPosition = Mathf.PingPong(Time.time * oscillationSpeed, to - from) + from;
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (!isActivated)
        {
            Move();
        }
    }

    public bool IsActivated()
    {
        return isActivated;
    }
}
