using Toweristika.Other;

namespace Toweristika.Ecs
{    
    public class Resistance
    {     
        public Percent Percent { get; set; }
        public DamageType DamageType { get; set; }

        public Resistance(float percent, DamageType damageType)
        {
            Percent = new Percent(percent);
            DamageType = damageType;
        }
    }
}