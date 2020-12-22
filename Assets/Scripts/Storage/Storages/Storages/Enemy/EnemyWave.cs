using System;
using Toweristika.Ecs;
using Toweristika.Other;

namespace Toweristika.Storage
{
    [Serializable]
    public class EnemyWave : IIteratable<EnemyGroup>
    {
        public EnemyGroup[] groups;

        private int index = 0;

        public EnemyGroup GetCurrent()
        {
            return index >= groups.Length ? null : groups[index];
        }

        public bool IsDone()
        {
            return groups.Length == 0 || index == groups.Length;
        }

        public void Next()
        {
            index++;
        }
    }
}