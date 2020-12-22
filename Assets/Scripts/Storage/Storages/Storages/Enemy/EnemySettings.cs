using UnityEngine;

namespace Toweristika.Storage
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "MyAssets/Storages/EnemySettings")]
    public class EnemySettings : Storage
    {
        public EnemyWaves Waves;
        public float SpawnPause;
    }
}