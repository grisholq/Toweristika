using LeopotamGroup.Ecs;

namespace Toweristika.Ecs
{
    public class WaySystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<WayObjects> wayObjectsFilter = null;
        
        private EcsFilter<AddWayObjectEvent> addWayObjectEvent = null;
        private EcsFilter<RemoveWayObjectEvent> removeWayObjectEvent = null;

        public void Initialize()
        {
            world.CreateEntityWith<WayObjects>();
        }

        public void Destroy()
        {
            
        }

        public void Run()
        {
            
        }

        public void RunEvents()
        {
            if(addWayObjectEvent.EntitiesCount != 0)
            {
                for (int i = 0; i < addWayObjectEvent.EntitiesCount; i++)
                {
                    wayObjectsFilter.Data.AddWayObject(addWayObjectEvent.Components1[0]);
                }
            }

            if (removeWayObjectEvent.EntitiesCount != 0)
            {
                for (int i = 0; i < removeWayObjectEvent.EntitiesCount; i++)
                {
                    wayObjectsFilter.Data.RemoveWayObject(removeWayObjectEvent.Components1[0]);
                }
            }
        }
    }
}