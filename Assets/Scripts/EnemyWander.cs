using System.Collections;
using UnityEngine;

public class EnemyWander : MonoBehaviour
{
    public float chaseSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    public float shootingCooldown = 2.0f;

    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;

    private Transform player;
    private bool canShoot = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(ChasePlayer());
        StartCoroutine(ShootingCooldown());
    }

    void Update()
    {
        if (canShoot)
        {
            Shoot();
        }
    }

    IEnumerator ChasePlayer()
    {
        while (true)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > 3.0f)
            {
                Vector3 playerXZPosition = new Vector3(player.position.x, 0, player.position.z);
                Vector3 enemyXZPosition = new Vector3(transform.position.x, 0, transform.position.z);

                Vector3 directionToPlayer = (playerXZPosition - enemyXZPosition).normalized;

                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                transform.position += transform.forward * chaseSpeed * Time.deltaTime;
            }

            yield return null;
        }
    }

    void Shoot()
    {
        fireball = Instantiate(fireballPrefab, transform.position + transform.forward * 1.5f, transform.rotation);

        Rigidbody fireballRb = fireball.GetComponent<Rigidbody>();

        fireballRb.velocity = transform.forward * 50;

        canShoot = false;
    }

    IEnumerator ShootingCooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingCooldown);
            canShoot = true;
        }
    }
}
