using UnityEngine;
using Toweristika.Other;

namespace Toweristika.Storage
{
    [CreateAssetMenu(fileName = "CameraSettings", menuName = "MyAssets/Storages/CameraSettings")]
    public class CameraSettings : Storage
    {
        public float MoveSpeed;
        public Range BorderX;
        public Range BorderY;
        public Range BorderZ;
    }
}

