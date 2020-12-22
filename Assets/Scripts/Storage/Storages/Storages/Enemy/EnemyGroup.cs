using System;
using Toweristika.Ecs;
using Toweristika.Other;

namespace Toweristika.Storage
{
    [Serializable]
    public class EnemyGroup : IIteratable<EnemyPrefab>
    {
        public EnemyPrefab enemy;
        public int amount;

        private int index = 0;

        public EnemyPrefab GetCurrent()
        {
            return index >= amount ? null : enemy;
        }

        public bool IsDone()
        {
            return amount == 0 || index == amount;
        }

        public void Next()
        {
            index++;
        }
    }
}