using UnityEngine;

public class BackstabberPathScript : MonoBehaviour
{

    public float orbitSpeed = 30f;    // Degrees per second around player
    public float inwardSpeed = 3.5f;     // How fast it moves toward player

    private Transform player;
    private float currentAngle;
    private float currentDistance;
    private int spiralDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Calculate initial distance and angle from player
        Vector3 toEnemy = transform.position - player.position;
        currentDistance = toEnemy.magnitude;
        currentAngle = Mathf.Atan2(toEnemy.y, toEnemy.x) * Mathf.Rad2Deg;

        // Randomly choose spiral direction
        spiralDirection = Random.Range(0, 2) * 2 - 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Orbit around player (direction determined by spiralDirection)
        currentAngle += orbitSpeed * Time.deltaTime * spiralDirection;

        // Move inward toward player
        currentDistance -= inwardSpeed * Time.deltaTime;

        // Calculate new position
        float angleRad = currentAngle * Mathf.Deg2Rad;
        Vector3 offset = new Vector3(
            Mathf.Cos(angleRad) * currentDistance,
            Mathf.Sin(angleRad) * currentDistance,
            0
        );

        transform.position = player.position + offset;

        // Optional: Make enemy face direction of movement
        transform.up = (player.position - transform.position).normalized;
    }
}
