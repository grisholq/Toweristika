using Toweristika.Other;

namespace Toweristika.Ecs
{
    public class EnemyRecievedDamageEvent
    {
        public IDamagable Enemy { get; set; }
        public IDamaging Source { get; set; }
    }
}