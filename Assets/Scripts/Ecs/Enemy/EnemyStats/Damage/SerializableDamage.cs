using System;
using Toweristika.Other;

namespace Toweristika.Ecs
{
    [Serializable]
    public class SerializableDamage
    {
        public float Value;
        public DamageType DamageType;
    }
}