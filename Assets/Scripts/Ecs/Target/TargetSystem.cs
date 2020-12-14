using UnityEngine;
using LeopotamGroup.Ecs;

namespace Toweristika.Ecs
{
    [EcsInject]
    public class TargetSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<TargetChooser> targetChooserFilter = null;

        public void Initialize()
        {
            world.CreateEntityWith<TargetChooser>().Inizialize();
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            
        }
    }
}