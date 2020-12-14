using UnityEngine;

namespace Toweristika.Ecs
{
    public class TouchInputProcessor : IInputProcessor
    {
        public void ProcessInput(InputData inputData)
        {            
            Touch touch;
            if(Input.touchCount != 1)
            {
                return;
            }
           
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                inputData.Position = touch.position;
                inputData.StartPosition = touch.position;
                inputData.Phase = TouchPhase.Began;
                inputData.isMoving = false;
                return;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                inputData.PreviousPosition = inputData.Position;
                inputData.Position = touch.position;
                inputData.Phase = TouchPhase.Moved;
                return;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                inputData.PreviousPosition = inputData.Position;
                inputData.Position = touch.position;
                inputData.Phase = TouchPhase.Ended;
                return;
            }

            inputData.Reset();
        }
    }
}