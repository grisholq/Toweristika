using UnityEngine;

namespace Toweristika.Ecs
{
    public class WayPointMono : MonoBehaviour
    {
        [SerializeField] private WayPointMono nextWaypoint;
        [SerializeField] [Range(0f, 1f)] private float speed;

        public WayPointMono NextWaypoint
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