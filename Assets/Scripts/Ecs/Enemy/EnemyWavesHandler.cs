using UnityEngine;
using Toweristika.Other;
using Toweristika.Storage;

namespace Toweristika.Ecs
{
    public class EnemyWavesHandler : IInizializable
    {
        private IIteratable<EnemyWave> waves;

        public bool IsWavesEnded
        {
            get
            {
                return waves.IsDone();
            }
        }

        public void Inizialize()
        {
            waves = StorageFacility.Instance.GetStorageByType<EnemySettings>().Waves;
        }

        public EnemyWave GetCurrentWave()
        {
            return waves.GetCurrent();
        }

        public void NextWave()
        {
            waves.Next();
        }
    }
}