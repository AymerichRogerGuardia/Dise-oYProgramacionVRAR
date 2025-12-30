using UnityEngine;

public class HealthUpPowerUpScript : MonoBehaviour
{

    public GameObject smallExplosionPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealthScript playerHealth = other.GetComponent<PlayerHealthScript>();
            if (playerHealth != null && playerHealth.currentHealth < 3)
            {
                playerHealth.currentHealth += 1;
                playerHealth.healthBar.UpdateHearts(playerHealth.currentHealth);
            }
            else if (playerHealth != null && playerHealth.currentHealth > 2)
            {
                Instantiate(smallExplosionPrefab, other.transform.position, Quaternion.identity);
            }

                Destroy(gameObject);
        }
    }
}