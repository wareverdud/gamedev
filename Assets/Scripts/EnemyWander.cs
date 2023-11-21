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
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            transform.position += transform.forward * chaseSpeed * Time.deltaTime;

            yield return null;
        }
    }

    void Shoot()
    {
        fireball = Instantiate(fireballPrefab, transform.position + transform.forward * 1.5f, transform.rotation);

        Rigidbody fireballRb = fireball.GetComponent<Rigidbody>();

        fireballRb.velocity = transform.forward * 25;

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
