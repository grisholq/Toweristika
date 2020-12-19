using Toweristika.Ecs;

namespace Toweristika.Other
{
    public interface IDamagable
    {
        void ApplyDamage(DamageGroup damage);
    }
}