﻿using UnityEngine;

namespace Toweristika.Ecs
{
    public class WaypointsMono : MonoBehaviour
    {
        [SerializeField] private WaypointMono[] waypoints;

        public WaypointMono GetWaypoint(int index)
        {
            return waypoints[index];
        }

        public WaypointMono GetFirstWaypoint()
        {
            return waypoints[0];
        }

        public WaypointMono GetLastWaypoint()
        {
            return waypoints[waypoints.Length - 1];
        }
    }
}