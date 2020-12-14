using UnityEngine;
using LeopotamGroup.Ecs;

namespace Toweristika.Ecs
{
    [EcsInject]
    public class InputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<InputHandler> inputHandlerFilter = null;
        private EcsFilterSingle<InputData> inputDataFilter = null;

        public void Initialize()
        {
            world.CreateEntityWith<InputHandler>().Inizialize();
            world.CreateEntityWith<InputData>();
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            inputHandlerFilter.Data.ProcessInput(inputDataFilter.Data);
        }
    }
}