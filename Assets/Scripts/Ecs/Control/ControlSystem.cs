using UnityEngine;
using LeopotamGroup.Ecs;

namespace Toweristika.Ecs
{
    [EcsInject]
    public class ControlSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<ControlHandler> controlHandlerFilter = null;
        private EcsFilterSingle<InputData> inputDataFilter = null;

        public void Initialize()
        {
            world.CreateEntityWith<ControlHandler>();
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            controlHandlerFilter.Data.ProcessControl(inputDataFilter.Data);
        }
    }
}