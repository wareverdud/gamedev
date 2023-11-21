using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    public int damage = 20;
    public float lifespan = 5.0f;

    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
