using UnityEngine;

public class BaseEnemiesScript : MonoBehaviour
{

    public GameObject explosionPrefab;

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
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionPrefab, other.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet") || other.CompareTag("Shield") || other.CompareTag("SmallExplosion") || other.CompareTag("BigExplosion"))
        {
            ScoreManager.instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
