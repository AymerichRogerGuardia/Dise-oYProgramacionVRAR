using UnityEngine;

public class ShieldPowerUpScript : MonoBehaviour
{
    public float duration = 10f;
    private GameObject shield;
    private static float shieldEndTime = 0f;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Transform shieldTransform = player.transform.Find("Shield");
            if (shieldTransform != null)
            {
                shield = shieldTransform.gameObject;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Calculate new end time
            float newEndTime = Time.time + duration;

            // Extend shield duration if new time is later
            if (newEndTime > shieldEndTime)
            {
                shieldEndTime = newEndTime;
            }

            // Enable shield and restart timer
            shield.SetActive(true);
            CancelInvoke("DisableShield");
            Invoke("DisableShield", shieldEndTime - Time.time);

            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }

    void DisableShield()
    {
        shield.SetActive(false);
        shieldEndTime = 0f;
        Destroy(gameObject);
    }
}