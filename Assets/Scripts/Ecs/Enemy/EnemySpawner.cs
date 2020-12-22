using UnityEngine;
using Toweristika.Other;
using Toweristika.Storage;

namespace Toweristika.Ecs
{
    public class EnemySpawner
    {
        private IIteratable<EnemyGroup> groups;
        private IIteratable<EnemyPrefab> group;

        public bool IsWaveEnded
        {
            get
            {
                return groups == null || (groups.IsDone() && group.IsDone());
            }
        }

        public void SetEnemyWave(EnemyWave wave)
        {
            if(wave == null || wave.IsDone()) return;
            groups = wave;
            group = groups.GetCurrent();
        }

        public Enemy GetEnemy()
        {   
            while(group.IsDone() && !groups.IsDone())
            {
                groups.Next();
                group = groups.GetCurrent();
            }

            if (IsWaveEnded) return null;

            EnemyPrefab enemyPrefab = group.GetCurrent();
            Enemy enemy = Object.Instantiate(enemyPrefab.prefab).gameObject.AddComponent<Enemy>();
            enemy.Inizialize(enemyPrefab.enemyStats);
            return enemy;
        }      
    }
}