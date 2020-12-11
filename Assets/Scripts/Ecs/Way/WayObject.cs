using UnityEngine;
using System;

namespace Toweristika.Ecs
{
    public class WayObject
    {
        private IMovable moveableObject;
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
                delta = (destination.Position - moveableObject.GetPosition()).normalized;
            }
        }

        public bool Arrived { get; private set; }

        public Action OnArrivalCallback { get; set; }

        public WayObject(IMovable movable, WaypointMono start, WaypointMono dest)
        {
            moveableObject = movable;
            moveableObject.SetPosition(start.Position);
            destination = dest;
            Arrived = false;
        }

        public void Move()
        {
            if (Arrived) return;

            float d1 = delta.magnitude;
            float d2 = (moveableObject.GetPosition() - destination.Position).magnitude;

            if (d1 >= d2)
            {
                moveableObject.SetPosition(destination.Position);
                OnDestinationReached();
            }
            else
            { 
                moveableObject.Move(delta); 
            }  
        }  

        private void OnDestinationReached()
        {
            if(destination.NextWaypoint == null)
            {
                Arrived = true;
                return;
            }

            destination = destination.NextWaypoint;
        }      
    }
}