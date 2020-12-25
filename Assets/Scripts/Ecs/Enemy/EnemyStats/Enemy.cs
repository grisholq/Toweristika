using System;
using Toweristika.Other;
using UnityEngine;

namespace Toweristika.Ecs
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public EnemyHealth Health { get; private set; }
        public DamageGroup DamageGroup { get; private set; }
        public ResistanceGroup ResistanceGroup { get; private set; }

        private float speed;

        public void Inizialize(EnemyStats enemyStats)
        {
            Health = new EnemyHealth(enemyStats.health, enemyStats.minHealth, enemyStats.maxHealth);
            InizializeDamage(enemyStats.damages);
            InizializeResistance(enemyStats.resistances);
            speed = enemyStats.speed;
        }

        private void InizializeDamage(SerializableDamage[] damages)
        {
            DamageGroup = new DamageGroup(damages.Length);
            SerializableDamage damage;
            for (int i = 0; i < damages.Length; i++)
            {
                damage = damages[i];
                DamageGroup.AddDamage(new Damage(damage.Value, damage.DamageType));
            }
        }

        private void InizializeResistance(SerializableResistance[] resistances)
        {
            ResistanceGroup = new ResistanceGroup(resistances.Length);
            SerializableResistance resistance;
            for (int i = 0; i < resistances.Length; i++)
            {
                resistance = resistances[i];
                ResistanceGroup.AddResistance(new Resistance(resistance.Percent, resistance.DamageType));
            }
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(float speed)
        {
            speed = Mathf.Max(0, speed);
        }

        public void Move(Vector3 delta)
        {
            transform.position += delta;
        }
      
        public void ApplyDamage(DamageGroup damageGroup)
        {                 
            Damage damage;
            Resistance resistance;

            if (ResistanceGroup.Count == 0) return;

            for (int i = 0; i < damageGroup.Count; i++)
            {
                damage = damageGroup.GetDamage(i);
                resistance = ResistanceGroup.FindResistance(r => r.DamageType == damage.DamageType);

                float adjustedDamage = resistance == null ? damage.Value : resistance.Percent.PercentToValue(0, damage.Value);
                Health.ApplyDamage(adjustedDamage);
            }
        }

        public void ApplyHealing(float heal)
        {
            Health.ApplyHealing(heal);
        }

        public void Damage(IDamagable damagable)
        {
            damagable.ApplyDamage(DamageGroup);
        }

        public void Die()
        {
            
        }
    }
}