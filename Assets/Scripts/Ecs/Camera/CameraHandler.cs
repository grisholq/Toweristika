using UnityEngine;
using Toweristika.Other;
using Toweristika.Storage;

namespace Toweristika.Ecs
{
    public class CameraHandler : IInizializable
    {
        private Transform camera;
        private CameraSettings settings;

        public void Inizialize()
        {
            camera = StorageFacility.Instance.GetTransform(TransformObject.Camera);
            settings = StorageFacility.Instance.GetStorageByType<CameraSettings>();
        }

        public void MoveCamera(CameraMoveEvent moveEvent)
        {
            camera.position += moveEvent.Delta * settings.MoveSpeed;
        }

        public void SetCameraPosition(CameraSetPositionEvent setEvent)
        {
            camera.position = setEvent.Position;
        }
    }
}