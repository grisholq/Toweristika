using UnityEngine;

namespace Toweristika.Ecs
{
    public interface IMovable
    {
        void Move(Vector3 delta);
        Vector3 GetPosition();
        void SetPosition(Vector3 position);
        float GetSpeed();          
    }
}