using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject bossPrefab;
    public GameObject[] miniEnemyPrefabs;
    public int bossRound;
    public GameObject[] EnemyPrefabs;
    public GameObject[] powerPrefabs;
    private float spawnRange = 9f;
    public int enemyCount;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        int randomPowerup = Random.Range(0, powerPrefabs.Length);
        Instantiate(powerPrefabs[randomPowerup], GenerateSpawnPosition(), powerPrefabs[randomPowerup].transform.rotation);
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
    void SpawnBossWave(int currentRound)
    {
        int miniEnemysToSpawn;
        //We dont want to divide by 0!
        if (bossRound != 0)
        {
            miniEnemysToSpawn = currentRound / bossRound;
        }
        else
        {
            miniEnemysToSpawn = 1;
        }
        var boss = Instantiate(bossPrefab, GenerateSpawnPosition(),
        bossPrefab.transform.rotation);
        boss.GetComponent<Enemy>().miniEnemySpawnCount = miniEnemysToSpawn;
    }
    public void SpawnMiniEnemy(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int randomMini = Random.Range(0, miniEnemyPrefabs.Length);
            Instantiate(miniEnemyPrefabs[randomMini], GenerateSpawnPosition(),
            miniEnemyPrefabs[randomMini].transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int enemyIndex = Random.Range(0, EnemyPrefabs.Length);
            Instantiate(EnemyPrefabs[enemyIndex], GenerateSpawnPosition(), EnemyPrefabs[enemyIndex].transform.rotation);
        }
    }
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            //Spawn a boss every x number of waves
            if (waveNumber % bossRound == 0)
            {
                SpawnBossWave(waveNumber);
            }
            else
            {
                SpawnEnemyWave(waveNumber);
            }
            //Updated to select a random powerup prefab for the Medium Challenge
            int randomPowerup = Random.Range(0, powerPrefabs.Length);
            Instantiate(powerPrefabs[randomPowerup], GenerateSpawnPosition(),
            powerPrefabs[randomPowerup].transform.rotation);
        }
    }

}
