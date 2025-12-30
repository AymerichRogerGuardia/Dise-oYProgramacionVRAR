using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject[] powerUpPrefabs;
    public Transform player;
    public float spawnRadius = 50f;

    private float enemyTimer = 0f;
    private float powerUpTimer = 0f;

    void Update()
    {
        // Spawn enemy every x seconds
        enemyTimer += Time.deltaTime;
        if (enemyTimer >= 0.5f)
        {
            SpawnRandomEnemy();
            enemyTimer = 0f;
        }

        // Spawn power-up every x seconds
        powerUpTimer += Time.deltaTime;
        if (powerUpTimer >= 10f)
        {
            SpawnRandomPowerUp();
            powerUpTimer = 0f;
        }
    }

    void SpawnRandomEnemy()
    {
        GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Vector3 spawnPos = GetRandomSpawnPosition();
        Instantiate(randomEnemy, spawnPos, Quaternion.identity);
    }

    void SpawnRandomPowerUp()
    {
        float rarity = Random.Range(0f, 100f);
        GameObject randomPowerUp;

        if (rarity < 3f)
        {
            randomPowerUp = powerUpPrefabs[3]; // Nuke
        }
        else if (rarity < 10f)
        {
            randomPowerUp = powerUpPrefabs[2]; //HealthUp PowerUP
        }
        else
        {
            randomPowerUp = powerUpPrefabs[Random.Range(0, 2)];
        }

        Vector3 spawnPos = GetRandomSpawnPosition();
        Instantiate(randomPowerUp, spawnPos, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        return player.position + new Vector3(randomCircle.x, randomCircle.y, 0);
    }
}