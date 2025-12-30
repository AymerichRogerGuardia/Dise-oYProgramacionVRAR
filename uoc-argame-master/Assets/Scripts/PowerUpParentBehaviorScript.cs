using UnityEngine;

public class PowerUpParentBehaviorScript : MonoBehaviour
{

    public int powerUpHitPoints = 5;
    public GameObject smallExplosionPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            powerUpHitPoints -= 1;
        }

        if (powerUpHitPoints <= 0)
        {
            Instantiate(smallExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
