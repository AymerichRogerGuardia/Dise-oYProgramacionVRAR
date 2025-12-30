using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 40f;
    public float lifetime = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
}
