using UnityEngine;

public class PlayerProjectileController : MonoBehaviour
{
    public float lifespan = 5.0f;

    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int damage = Random.Range(10, 21);
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
