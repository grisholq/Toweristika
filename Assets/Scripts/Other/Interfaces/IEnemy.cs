using Toweristika.Ecs;

namespace Toweristika.Other
{
    public interface IEnemy : IMovable, IDamagable, IDamaging, IHealable
    {
        void Die();
    }
}