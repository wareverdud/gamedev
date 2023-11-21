using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public int damage = 20;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyTag"))
        {
            other.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
