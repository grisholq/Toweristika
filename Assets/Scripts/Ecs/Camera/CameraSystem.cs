using UnityEngine;
using LeopotamGroup.Ecs;

namespace Toweristika.Ecs
{
    [EcsInject]
    public class CameraSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<CameraHandler> cameraHandlerFilter = null;

        private EcsFilter<CameraMoveEvent> cameraMoveEvents = null;
        private EcsFilter<CameraSetPositionEvent> cameraPositionEvents = null;

        public void Initialize()
        {
            world.CreateEntityWith<CameraHandler>().Inizialize();
        }

        public void Destroy()
        {

        }

        public void Run()
        {


            RunEvents();
        }

        private void RunEvents()
        {
            if (cameraPositionEvents.EntitiesCount != 0)
            {
                for (int i = 0; i < cameraPositionEvents.EntitiesCount; i++)
                {
                    cameraHandlerFilter.Data.SetCameraPosition(cameraPositionEvents.Components1[i]);
                }
            }

            if (cameraMoveEvents.EntitiesCount != 0)
            {
                for (int i = 0; i < cameraMoveEvents.EntitiesCount; i++)
                {
                    cameraHandlerFilter.Data.MoveCamera(cameraMoveEvents.Components1[i]);                   
                }
            }
        }
    }
}