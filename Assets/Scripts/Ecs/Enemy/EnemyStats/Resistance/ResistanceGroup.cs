using System;
using System.Collections.Generic;

namespace Toweristika.Ecs
{
    public class ResistanceGroup
    {
        private List<Resistance> resistances;

        public int Count
        {
            get
            {
                return resistances.Count;
            }
        }

        public ResistanceGroup(int capacity)
        {
            resistances = new List<Resistance>(capacity);
        }

        public void AddResistance(Resistance resistance)
        {
            Resistance res = FindResistance(i => i.DamageType.Equals(resistance.DamageType));
            
            if(res != null)
            {
                res.DamageType = resistance.DamageType;
                res.Percent = resistance.Percent;
                return;
            }
            resistances.Add(resistance);
        }

        public Resistance GetResistance(int index)
        {
            if (resistances == null || index >= Count) return null;
            return resistances[index];
        }

        public Resistance FindResistance(Predicate<Resistance> predicate)
        {
            return resistances.Find(predicate);
        }
    }
}