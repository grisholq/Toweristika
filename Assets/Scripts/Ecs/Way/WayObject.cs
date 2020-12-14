using UnityEngine;
using System;

namespace Toweristika.Ecs
{
    public class WayObject
    {
        private IMovable moveable;
        private WayPointMono destination;       
       
        private Vector3 delta;

        public WayPointMono Destination
        {
            get
            {
                return destination;
            }

            set
            {
                destination = value;
                delta = (destination.Position - moveable.GetPosition()).normalized;
            }
        }

        public IMovable Moveable
        {
            get
            {
                return moveable;
            }
        }

        public bool Arrived { get; private set; }

        public Action OnArrivalCallback { get; set; }

        public WayObject(IMovable movable, WayPointMono start)
        {
            moveable = movable;
            moveable.SetPosition(start.Position);
            Destination = start;
            Arrived = false;
        }

        public void Move()
        {
            if (Arrived) return;

            float d1 = delta.magnitude * moveable.GetSpeed();
            float d2 = (moveable.GetPosition() - Destination.Position).magnitude;

            if (d1 >= d2)
            {
                moveable.SetPosition(Destination.Position);
                OnDestinationReached();
            }
            else
            { 
                moveable.Move(delta); 
            }  
        }  

        private void OnDestinationReached()
        {
            if(Destination.NextWaypoint == null)
            {
                Arrived = true;
                return;
            }

            Destination = Destination.NextWaypoint;
        }      
    }
}