using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    DateTime LastSpawnedEnemyTime;

    public int SpawnedEnemiesCount;

    public GameObject EnemyPrefab;

    public List<GameObject> EnemiesOnScreen;

    public float SpawnRate = 0.3f;

    private System.Random rnd;

    public GameObject Player;

    private bool IsActive = false;

    public List<EnemyController> EnemiesToSpawn;

    private int MaxEnemiesPerScreen;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        LastSpawnedEnemyTime = DateTime.Now;
        EnemiesOnScreen = new();
    }

    public void StartSpawnEnemies(List<EnemyController> EnemiesCount, int MaxEnemies = 10)
    {
        EnemiesToSpawn = EnemiesCount;
        MaxEnemiesPerScreen = MaxEnemies;
        IsActive = true;
        SpawnedEnemiesCount = 0;
        EnemiesOnScreen = new();
    }

    public void SpawnBoss(int health, int damage)
    {
        var enemy = Instantiate(
                EnemyPrefab,
                new Vector3((float)rnd.NextDouble() * 5f, (float)rnd.NextDouble() * 5f, (float)rnd.NextDouble() * 5f),
                Quaternion.identity);
        enemy.GetComponent<EnemyController>().Target = Player;
        enemy.GetComponent<EnemyController>().HP = health;
        enemy.GetComponent<EnemyController>().Damage = damage;
    }


    // Update is called once per frame
    void Update()
    {
        if (!IsActive)
        {
            return;
        }

        if (SpawnedEnemiesCount < EnemiesToSpawn.Count)
        {
            if (LastSpawnedEnemyTime.AddMilliseconds(SpawnRate * 1000) > DateTime.Now || EnemiesOnScreen.Count >= MaxEnemiesPerScreen)
            {
                return;
            }

            LastSpawnedEnemyTime = DateTime.Now;

            var enemy = Instantiate(
                EnemyPrefab, 
                new Vector3((float)rnd.NextDouble() * 5f, (float)rnd.NextDouble() * 5f, (float)rnd.NextDouble() * 5f), 
                Quaternion.identity);
            enemy.GetComponent<EnemyController>().Target = Player;
            SpawnedEnemiesCount++;
            EnemiesOnScreen.Add(enemy);
        }
        else
        {
            IsActive = false;
        }
    }
}
