using System;

namespace Toweristika.Ecs
{   
    [Serializable]
    public class EnemyStats
    {
        public SerializableDamage[] damages;
        public SerializableResistance[] resistances;
        public float health;
        public float maxHealth;
        public float minHealth;
        public float speed;       
    }
}