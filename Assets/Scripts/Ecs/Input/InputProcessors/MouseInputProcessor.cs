using UnityEngine;

namespace Toweristika.Ecs
{
    public class MouseInputProcessor : IInputProcessor
    {
        public void ProcessInput(InputData inputData)
        {
            bool started = Input.GetMouseButtonDown(0);
            bool moving = Input.GetMouseButton(0);
            bool ended = Input.GetMouseButtonUp(0);

            if(started)
            {
                inputData.Position = Input.mousePosition;
                inputData.StartPosition = Input.mousePosition;
                inputData.Phase = TouchPhase.Began;                
                inputData.isMoving = false;
                return;
            }

            if(moving)
            {
                inputData.PreviousPosition = inputData.Position;
                inputData.Position = Input.mousePosition;
                inputData.Phase = TouchPhase.Moved; 
                return;
            }

            if(ended)
            {
                inputData.PreviousPosition = inputData.Position;
                inputData.Position = Input.mousePosition;
                inputData.Phase = TouchPhase.Ended; 
                return;
            }

            inputData.Reset();
        }
    }
}