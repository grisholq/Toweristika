using UnityEngine;
using Toweristika.Other;
using Toweristika.Storage;

namespace Toweristika.Ecs
{
    public class CameraHandler : IInizializable
    {
        private Camera camera;
        private CameraSettings settings;

        public void Inizialize()
        {
            camera = StorageFacility.Instance.GetTransform(TransformObject.Camera).GetComponent<Camera>();
            settings = StorageFacility.Instance.GetStorageByType<CameraSettings>();
            SetCameraPosition(settings.StartPosition);
        }

        public void MoveCamera(Vector3 delta)
        {
            delta = new Vector3(delta.x, 0, delta.y);        
            camera.transform.position += delta * settings.MoveSpeed;
            ApplyCameraBorders();
        }

        public void SetCameraPosition(Vector3 position)
        {
            camera.transform.position = position;
            ApplyCameraBorders();
        }

        private void ApplyCameraBorders()
        {
            Vector3 pos = camera.transform.position;
            pos.x = settings.BorderX.Clamp(pos.x);
            pos.y = settings.BorderY.Clamp(pos.y);
            pos.z = settings.BorderZ.Clamp(pos.z);
            camera.transform.position = pos;
        }
    }
}