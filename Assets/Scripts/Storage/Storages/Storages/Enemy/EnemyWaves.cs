using System;
using Toweristika.Ecs;
using Toweristika.Other;

namespace Toweristika.Storage
{
    [Serializable]
    public class EnemyWaves : IIteratable<EnemyWave>
    {
        public EnemyWave[] waves;

        private int index;

        public EnemyWave GetCurrent()
        {
            return index >= waves.Length ? null : waves[index];
        }

        public bool IsDone()
        {
            return waves.Length == 0 || index == waves.Length;
        }

        public void Next()
        {
            index++;
        }
    }
}