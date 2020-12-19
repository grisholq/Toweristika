using UnityEngine;

namespace Toweristika.Other
{
    public class Health : ClampedValue
    {
        [SerializeField] private float healthPoints;

        public float HealthPoints
        { 
            get
            {
                return healthPoints;
            }

            private set
            {
                healthPoints = HealthBorders.Clamp(value);
            }
        }

        public Range HealthBorders { get; set; }

        public Health()
        {
            HealthPoints = HealthBorders.Max;
        }

        public Health(float health, float min, float max)
        {
            HealthBorders = new Range();
            HealthBorders.Min = min;
            HealthBorders.Max = max;
            HealthPoints = HealthBorders.Clamp(health);
        }

        public void ApplyDamage(float damage)
        {
            HealthPoints -= damage;
            HealthPoints = HealthBorders.Clamp(HealthPoints);
        }

        public void ApplyHealing(float healing)
        {
            HealthPoints += healing;
            HealthPoints = HealthBorders.Clamp(HealthPoints);
        }
    }
}