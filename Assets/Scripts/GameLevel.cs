using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class GameLevel
    {
        public List<EnemyController> EnemiesToSpawn { get; set; }

        public bool HasBoss { get; set; } = false;

        public int BossHP { get; set; }

        public int BossDamage { get; set; }
    }

    public static class GameLevelExtensions
    {
        public static async void StartLevel(this GameLevel gameLevel, EnemySpawner enemySpawner)
        {
            enemySpawner.StartSpawnEnemies(gameLevel.EnemiesToSpawn);
            await WaitToSpawnEnemies(gameLevel, enemySpawner);
            enemySpawner.SpawnBoss(gameLevel.BossHP, gameLevel.BossDamage);
        }

        private async static Task<bool> WaitToSpawnEnemies(this GameLevel gameLevel, EnemySpawner enemySpawner)
        {
            while (enemySpawner.SpawnedEnemiesCount != enemySpawner.EnemiesToSpawn.Count)
            {
                await Task.Delay(1000);
            }
            return true;
        }
    }
}
