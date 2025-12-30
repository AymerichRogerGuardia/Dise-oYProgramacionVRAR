using UnityEngine;

public class FirePointScript : MonoBehaviour
{

    public GameObject bulletPrefab;
    public Transform firePoint;

    private float timer = 0f;
    public float fireRate = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            timer = 0f;
        }
    }
}
