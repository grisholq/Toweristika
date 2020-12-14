using UnityEngine;
using LeopotamGroup.Ecs;

namespace Toweristika.Ecs
{
    public class World : SingletonBase<World>
    {
        private EcsSystems systems;
        public EcsWorld Current { get; private set; }

        private void Start()
        {
            Current = new EcsWorld();
            systems = new EcsSystems(Current);

            systems
            .Add(new InputSystem())
            .Add(new ControlSystem())
            .Add(new CameraSystem())
            .Add(new TargetSystem())
            .Add(new WaySystem())
            .Add(new EnemySystem());
            

            systems.Initialize();
        }

        private void Update()
        {
            systems.Run();
        }

        public void RemoveEntitiesWith<T>() where T : class, new()
        {
            EcsFilter<T> filter = Current.GetFilter<EcsFilter<T>>();
            if (filter.EntitiesCount == 0) return;

            for (int i = 0; i < filter.EntitiesCount; i++)
            {
                Current.RemoveEntity(filter.Entities[i]);
            }
        }
    }
}