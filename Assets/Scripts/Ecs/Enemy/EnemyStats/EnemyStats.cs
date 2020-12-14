using System;
using UnityEngine;

namespace Toweristika.Ecs
{
    [Serializable]
    public struct EnemyStats
    {
        [SerializeField] private float health;
        [SerializeField] private float speed;
        [SerializeField] private float damage;
    }
}