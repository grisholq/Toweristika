using UnityEngine;

namespace Toweristika.Ecs
{
    public class WayObject
    {
        private IMovable @object;
        private WaypointMono destination;
        private Vector3 delta;

        public WaypointMono Destination
        {
            get
            {
                return destination;
            }

            set
            {
                destination = value;
                delta = (destination.Position - @object.GetPosition()).normalized;
            }
        }

        public bool Arrived
        {
            get
            {
                return @object.GetPosition() == destination.Position;
            }
        }

        public WayObject(IMovable movable, WaypointMono start, WaypointMono dest)
        {
            @object = movable;
            @object.SetPosition(start.Position);
            destination = dest;
        }

        public void Move()
        {
            float d1 = delta.magnitude;
            float d2 = (@object.GetPosition() - destination.Position).magnitude;

            if (d1 >= d2) @object.SetPosition(destination.Position);
            else @object.Move(delta);
        }     
    }
}