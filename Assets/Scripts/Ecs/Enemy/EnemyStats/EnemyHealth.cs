using Toweristika.Other;

namespace Toweristika.Ecs
{
    public class EnemyHealth : Health
    {
        public bool IsDead
        {
            get
            {
                return HealthPoints <= HealthBorders.Min;
            }
        }

        public EnemyHealth() : base() { }
        public EnemyHealth(float health, float min, float max) : base(health, min, max) { }      
    }
}