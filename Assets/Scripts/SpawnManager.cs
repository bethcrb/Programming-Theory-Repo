using System.Security.Cryptography;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;

    private float zEnemySpawn = 4.0f;
    private float xSpawnRange = 6.0f;
    private float ySpawn = 0.5f;
    private float zPowerupRange = 5.0f;

    private float powerupSpawnTime = 10.0f;
    private float enemySpawnTime = 2.0f;
    private float startDelay = 2.0f;

    private GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemy()
    {
        if (gameManager.isGameActive) {
            int randomIndex = Random.Range(0, enemies.Length);
            float enemyX = enemies[randomIndex].gameObject.transform.position.x;

            Vector3 spawnPos = new Vector3(enemyX, ySpawn, zEnemySpawn);

            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        if (gameManager.isGameActive)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            float randomZ = Random.Range(-zPowerupRange, zPowerupRange);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, randomZ);

            Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
        }
    }
}
