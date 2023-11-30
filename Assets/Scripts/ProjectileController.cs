using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float lifespan = 5.0f;

    void Start()
    {
        Destroy(gameObject, lifespan);
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyTag"))
        {
            int damage = Random.Range(15, 26);
            other.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
