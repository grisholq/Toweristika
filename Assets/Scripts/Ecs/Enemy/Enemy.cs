using UnityEngine;
using Toweristika.Other;

namespace Toweristika.Ecs
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public EnemyHealth health;
        public DamageGroup damageGroup;
        public ResistanceGroup resistanceGroup;
        public float speed;

        public void Inizialize(EnemyStats enemyStats)
        {
            health = new EnemyHealth(enemyStats.health, enemyStats.minHealth, enemyStats.maxHealth);

            damageGroup = new DamageGroup(enemyStats.damages.Length);
            SerializableDamage damage;
            for (int i = 0; i < enemyStats.damages.Length; i++)
            {
                damage = enemyStats.damages[i];
                damageGroup.AddDamage(new Damage(damage.Value, damage.DamageType));
            }

            resistanceGroup = new ResistanceGroup(enemyStats.resistances.Length);
            SerializableResistance resistance;
            for (int i = 0; i < enemyStats.damages.Length; i++)
            {
                resistance = enemyStats.resistances[i];
                resistanceGroup.AddResistance(new Resistance(resistance.Percent, resistance.DamageType));
            }

            speed = enemyStats.speed;
        }

        private void InizializeDamage()
        {

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

        public void Move(Vector3 delta)
        {
            transform.position += delta;
        }
      
        public void ApplyDamage(DamageGroup damage)
        {
            for (int i = 0; i < damage.Count; i++)
            {
                resistanceGroup.GetResistance(i);
            }
        }

        public void ApplyHealing(float heal)
        {
            
        }

        public void Damage(IDamagable damagable)
        {
            
        }

        public void Die()
        {

        }
    }
}