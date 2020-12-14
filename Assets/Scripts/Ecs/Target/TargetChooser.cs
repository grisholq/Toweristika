using UnityEngine;
using Toweristika.Other;
using Toweristika.Storage;

namespace Toweristika.Ecs
{
    public class TargetChooser : IInizializable
    {
        private Camera camera;
        
        public void Inizialize()
        {
            camera = StorageFacility.Instance.GetTransform(TransformObject.Camera).GetComponent<Camera>();
        }

        
    }
}