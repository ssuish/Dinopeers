using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class monsterSpawner : MonoBehaviour
{
   
    public List<Enemy> enemies = new List<Enemy>();
    public int currWave;
    private int waveValue;

    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public List<GameObject> spawnLocations = new List<GameObject>();

    public int waveDuration;
    private float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    
    void Start() 
    {
        currWave = 1;
        GenerateWave();
    }

    void FixedUpdate() 
    {
        if (spawnTimer <= 0)
        {
            if (enemiesToSpawn.Count > 0)
            {
                GameObject spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];
                GameObject enemy = Instantiate(enemiesToSpawn[0], spawnLocation.transform.position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }
            else 
            {
                waveTimer = 0;
            }
        }
        else
        {
            spawnTimer -= Time.deltaTime;
            waveTimer -= Time.deltaTime;
        }
    }

    public void GenerateWave() 
    {
        waveValue = currWave * 15;
        GenerateEnemies();
    }

    public void GenerateEnemies() 
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue > 0) 
        {
            Enemy enemy = enemies[Random.Range(0, enemies.Count)];
            if (waveValue - enemy.cost >= 0) 
            {
                waveValue -= enemy.cost;
                generatedEnemies.Add(enemy.enemyPrefab);
            }
            else if (waveValue<=0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

  
}
 
[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost;
}
 