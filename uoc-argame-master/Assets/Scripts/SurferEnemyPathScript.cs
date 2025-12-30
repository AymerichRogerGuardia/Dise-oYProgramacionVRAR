using UnityEngine;

public class SurferEnemyPathScript : MonoBehaviour
{

    public float speed = 2f;
    public float frequency = 2f; // wave speed
    public float amplitude = 1f; // wave width

    private Transform player;
    private Vector3 startPosition;
    private float timeCounter = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime;

        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        Vector3 perpendicular = new Vector3(-directionToPlayer.y, directionToPlayer.x, 0);

        float waveOffset = Mathf.Sin(timeCounter * frequency) * amplitude;

        transform.position += (directionToPlayer * speed + perpendicular * waveOffset) * Time.deltaTime;

        // test orientation
        transform.up = (player.position - transform.position).normalized;

    }
}
