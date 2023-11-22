using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public TextMeshProUGUI healthText;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        health = Mathf.Min(health, maxHealth);

        if (healthText != null)
        {
            healthText.text = health.ToString();
        }
    }

    public void Update()
    {
        if (healthText != null)
        {
            healthText.text = health.ToString();
        }
    }
}
