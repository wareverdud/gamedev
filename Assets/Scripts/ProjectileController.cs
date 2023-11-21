using UnityEngine;

public class ProjectileController : MonoBehaviour
{
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
