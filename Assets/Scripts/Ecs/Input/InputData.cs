using UnityEngine;

namespace Toweristika.Ecs
{
    public class InputData
    {
        public Vector2 Position { get; set; }
        public Vector2 PreviousPosition { get; set; }
        public Vector2 StartPosition { get; set; }
        public TouchPhase Phase { get; set; }
        public bool isMoving { get; set; }

        public void Reset()
        {
            Position = Vector2.zero;
            PreviousPosition = Vector2.zero;
            StartPosition = Vector2.zero;
            Phase = TouchPhase.Canceled;        
        }
    }
}