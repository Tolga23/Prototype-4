using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    public int enemyCount;
    public int vaweNumber = 1;
    public int powerUpCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(vaweNumber);
        SpawnPowerUp(powerUpCount);
    }

    // Update is called once per frame
    void Update()
    {
        // get length of enemy
        enemyCount = FindObjectsOfType<Enemy>().Length; 
        
        // new vawe
        if(enemyCount == 0)
        {
            vaweNumber++;
            SpawnEnemyWave(vaweNumber);
            SpawnPowerUp(powerUpCount);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnPowerUp(int powerUpSpawn)
    {
        for (int i = 0; i < powerUpSpawn; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        Vector3 randomPos = new Vector3(Random.Range(10, -10), 0, Random.Range(10, -10));

        return randomPos;
    }
}
