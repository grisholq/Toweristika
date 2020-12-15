using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toweristika.Other
{
    public class Health : ClampedValue, IDamagable, IHealable
    {
        [SerializeField] float healthPoints;

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

        public Health(int health)
        {
            HealthPoints = health;
            HealthPoints = HealthBorders.Clamp(HealthPoints);
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