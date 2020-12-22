using Toweristika.Other;

namespace Toweristika.Ecs
{
    public class EnemyRecievedHealingEvent
    {
        public IHealable Enemy { get; set; }
        public IHealing Source { get; set; }
    }
}