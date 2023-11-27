using UnityEngine;

public class CubeMaterialChange : MonoBehaviour
{
    public Material hitMaterial;
    public Material defaultMaterial;
    public bool isActivated = false;

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

    public bool IsActivated()
    {
        return isActivated;
    }
}
