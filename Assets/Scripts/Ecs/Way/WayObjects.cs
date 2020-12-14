using System.Collections.Generic;
using UnityEngine;
using Toweristika.Other;
using Toweristika.Storage;

namespace Toweristika.Ecs
{
    public class WayObjects : IInizializable, IProcessable
    {
        private WayPointsMono wayPoints;
        private List<WayObject> wayObjects;

        public void Inizialize()
        {
            wayPoints = StorageFacility.Instance
                .GetTransform(TransformObject.WayPoints)
                .GetComponent<WayPointsMono>();

            wayObjects = new List<WayObject>(50);
        }
        public void AddWayObject(AddWayObjectEvent add)
        {
            WayObject wayObject = new WayObject(add.Moveable, wayPoints.GetFirstWaypoint());
            wayObject.OnArrivalCallback = add.Callback;
            wayObjects.Add(wayObject);
        }
     
        public void RemoveWayObject(RemoveWayObjectEvent remove)
        {
            for (int i = 0; i < wayObjects.Count; i++)
            {
                if (wayObjects[i].Moveable == remove.Moveable)
                {
                    wayObjects.RemoveAt(i);
                    return;
                }
            }
        }

        public void Process()
        {
            if (wayObjects == null || wayObjects.Count == 0) return;
            ProcessArrivedWayObjects();
            ProcessWayObjects();
        }

        private void ProcessArrivedWayObjects()
        {
            wayObjects.RemoveAll((obj) => 
            { 
                if (obj.Arrived)
                {
                    obj.OnArrivalCallback();
                    return true;
                }
                return false;
            });
        }

        private void ProcessWayObjects()
        { 
            foreach (var wayObject in wayObjects)
            {
                wayObject.Move();
            }
        }
    }
}