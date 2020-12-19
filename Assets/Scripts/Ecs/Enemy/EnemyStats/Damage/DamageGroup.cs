using System;
using System.Collections.Generic;

namespace Toweristika.Ecs
{
    public class DamageGroup
    {
        private List<Damage> damages;
        
        public int Count
        {
            get
            {
                return damages.Count;
            }
        }

        public DamageGroup(int capacity)
        {
            damages = new List<Damage>(capacity);
        }

        public void AddDamage(Damage damage)
        {
            Damage dam = FindDamage(i => i.DamageType.Equals(damage.DamageType));

            if (dam != null)
            {
                dam.DamageType = damage.DamageType;
                dam.Value = damage.Value;
                return;
            }
            damages.Add(damage);
        }

        public Damage GetDamage(int index)
        {
            if (damages == null || index >= Count) return null;
            return damages[index];
        }

        public Damage FindDamage(Predicate<Damage> predicate)
        {
            return damages.Find(predicate);
        }
    }
}