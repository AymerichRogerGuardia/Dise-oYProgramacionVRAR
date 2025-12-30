using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{

    public int maxHealth = 3;
    public int currentHealth;
    public HealthBarScript healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHearts(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentHealth -= 1;
            healthBar.UpdateHearts(currentHealth);

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f;
    }
}
