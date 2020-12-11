using System;
using UnityEngine;
using Toweristika.Other;

namespace Toweristika.Ecs
{
    public class WayObject : IProcessable
    {
        private Transform wayObject;
        private Action onArrival;
        private WaypointMono destination;
        private Vector3 delta;

        public bool isArrived { get; private set; }

        public bool isValid
        {
            get
            {
                return wayObject != null;
            }
        }


        public WayObject(Transform transform, WaypointMono start, WaypointMono dest)
        {
            wayObject = transform;
            wayObject.position = start.Position;
            destination = dest;
        }

        public void Process()
        {
            if (isArrived) return;

            float d1 = delta.magnitude;
            float d2 = (wayObject.position - destination.Position).magnitude;

            if (d1 >= d2)
            {
                wayObject.position = destination.Position;
                OnDestinationReached();
            }
            else
            { 
                wayObject.position += delta; 
            } 
        }

        private void OnDestinationReached()
        {
            if (destination.NextWaypoint == null)
            {
                isArrived = true;
                return;
            }

            destination = destination.NextWaypoint;
        }
    }
}