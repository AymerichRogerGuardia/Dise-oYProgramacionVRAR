using UnityEngine;

public class ExplosionScript : MonoBehaviour
{

    public float growthSpeed = 25f;
    public float maxSize = 30f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += Vector3.one * growthSpeed * Time.deltaTime;

        if (transform.localScale.x >= maxSize)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("PowerUp"))
        {
            PowerUpParentBehaviorScript powerup = other.GetComponent<PowerUpParentBehaviorScript>();
            if (powerup != null)
            {
                powerup.powerUpHitPoints -= 1;
            }
        }
    }

}
