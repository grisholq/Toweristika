using UnityEngine;

namespace Toweristika.Ecs
{
    public interface IWayObject
    {
        void Move(Vector3 delta);
        void SetPosition(Vector3 position);
        Vector3 GetPosition();
        void OnArrival();
    }
}