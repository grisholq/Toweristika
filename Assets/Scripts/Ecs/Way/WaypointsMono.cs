using UnityEngine;

namespace Toweristika.Ecs
{
    public class WayPointsMono : MonoBehaviour
    {
        [SerializeField] private WayPointMono[] waypoints;
        [SerializeField] private int waypointsCount;


        public WayPointMono GetWaypoint(int index)
        {
            return waypoints[index];
        }

        public WayPointMono GetFirstWaypoint()
        {
            return waypoints[0];
        }

        public WayPointMono GetLastWaypoint()
        {
            return waypoints[waypoints.Length - 1];
        }
    }
}