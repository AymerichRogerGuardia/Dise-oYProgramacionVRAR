using UnityEngine;

public class FireRateUpBehaviorScript : MonoBehaviour
{
    public float newFireRate = 0.1f;
    public float duration = 7f;
    private float originalFireRate = 0.4f;
    private FirePointScript firePointScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide power-up
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            // Find the FirePoint GameObject and get its script
            GameObject firePoint = GameObject.Find("FirePoint");
            firePointScript = firePoint.GetComponent<FirePointScript>();

            // Apply boost and set revert timer
            firePointScript.fireRate = newFireRate;

            Invoke("RevertFireRate", duration);
        }
    }

    void RevertFireRate()
    {
        firePointScript.fireRate = originalFireRate;
        Destroy(gameObject);
    }
}