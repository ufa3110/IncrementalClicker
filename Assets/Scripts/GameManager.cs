using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EnemySpawner EnemySpawner;

    public int GameLevel = 1;

    public float EnemiesSpawnPercent;

    // Start is called before the first frame update
    void Start()
    {
        EnemySpawner.StartSpawnEnemies(new List<EnemyController>() { new EnemyController(3, 5), new EnemyController(3, 5) , new EnemyController(3, 5) });
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesSpawnPercent = EnemySpawner.SpawnedEnemiesCount / (float)EnemySpawner.EnemiesToSpawn.Count * 100;
    }
}
