using UnityEngine;

namespace Toweristika.Ecs
{
    [CreateAssetMenu(fileName ="EnemyPrefab", menuName = "MyAssets/Enemy")]
    public class EnemyPrefab : ScriptableObject
    {
        public Transform prefab;
        public EnemyStats enemyStats;
    }
}