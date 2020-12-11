using System;
using System.Collections.Generic;
using Toweristika.Other;
using UnityEngine;

namespace Toweristika.Ecs
{
    public class WayObjects : IProcessable
    {
        private LinkedList<WayObject> wayObjects;
        private WaypointsMono waypoints;

        public WayObjects()
        {
            wayObjects = new LinkedList<WayObject>();
        }

        public void AddWayObject(WayObject wayObject)
        {
            wayObjects.AddLast(wayObject);
        }

        public void Process()
        {
            LinkedListNode<WayObject> curr = wayObjects.First;
            WayObject obj = curr.Value;

            while (curr != null)
            {
                if(!obj.isValid || obj.isArrived)
                {

                }

                curr = curr.Next;
                obj = curr.Value;
            }
        }

        private void ProcessWayobject(WayObject wayObject)
        {           
            if (wayObject == null) return;

            if (wayObject.isArrived)
            {         
               
            }
            //wayObject.Move();
        }
        
        private void Remove(LinkedListNode<WayObject> node)
        {
            //LinkedListNode <WayObject> buf
        }

        private void RemoveAll(Predicate<WayObject> predicate)
        {
            LinkedListNode<WayObject> curr = wayObjects.First;

            while (curr != null)
            {
                if(predicate(curr.Value))
                {
                    LinkedListNode<WayObject> buf = curr;
                    curr = curr.Next;
                    wayObjects.Remove(buf);
                    continue;
                }

                curr = curr.Next;
            }
        }
    }
}