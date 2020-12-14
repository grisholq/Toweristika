using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toweristika.Other
{
    public class Health : IDamagable, IHealable
    {
        private float healthPoints;
        
        public float HealthPoints
        {
            get
            {
                return healthPoints;
            }
        }

        public void ApplyDamage(float damage)
        {
            
        }

        public void ApplyHealing(float heal)
        {
            
        }
    }

}
