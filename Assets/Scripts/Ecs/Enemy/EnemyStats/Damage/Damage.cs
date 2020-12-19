using Toweristika.Other;

namespace Toweristika.Ecs
{
    public class Damage
    {
        public float Value { get; set; }
        public DamageType DamageType { get; set; }

        public Damage(float value, DamageType damageType)
        {
            Value = value;
            DamageType = damageType;
        }
    }
}