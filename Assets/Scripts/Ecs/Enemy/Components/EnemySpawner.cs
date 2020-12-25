using UnityEngine;
using Toweristika.Other;
using Toweristika.Storage;

namespace Toweristika.Ecs
{
    public class EnemySpawner : IInizializable
    {
        private IIteratable<EnemyGroup> groups;
        private IIteratable<EnemyPrefab> group;
        private Transform enemyParent;

        public bool IsWaveEnded
        {
            get
            {
                return groups == null || (groups.IsDone() && group.IsDone());
            }
        }

        public void Inizialize()
        {
            enemyParent = StorageFacility.Instance.GetTransform(TransformObject.EnemyParent);
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
            enemy.transform.SetParent(enemyParent);
            return enemy;
        }        
    }
}