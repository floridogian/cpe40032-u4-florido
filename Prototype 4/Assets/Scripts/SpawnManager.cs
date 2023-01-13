using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Private Variables
    private float spawnRange = 9.0f; // Range where the enemy and poweup will spawn
    private int waveNumber = 1; // Variable for wave number in spawning the enemy

    // Public Variables
    public GameObject enemyPrefab; // Variable for enemy prefab
    public int enemyCount; // Variable for the count of enemy
    public GameObject powerupPrefab; // Variable for powerup prefab

    // Start is called before the first frame update
    void Start()
    {
        // Spawn the enemy and powerup
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        // Every wave, more enemies will spawn.
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Counts the enemy
        enemyCount = FindObjectsOfType<Enemy>().Length;

        // Once the all the enemies are gone, it will spawn enemy wave and powerup
        if(enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        // Positions where the enemy and powerup will spawn
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
