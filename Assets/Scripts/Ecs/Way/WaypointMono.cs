using UnityEngine;

namespace Toweristika.Ecs
{
    public class WaypointMono : MonoBehaviour
    {
        [SerializeField] private WaypointMono nextWaypoint;
        [SerializeField] [Range(0f, 1f)] private float speed;

        public WaypointMono NextWaypoint
        {
            get
            {
                return nextWaypoint;
            }
        }

        public float Speed
        {
            get
            {
                return speed;
            }
        }

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
        }
    }
}