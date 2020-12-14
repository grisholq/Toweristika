using UnityEngine;
using Toweristika.Other;
using Toweristika.Storage;

namespace Toweristika.Ecs
{
    public class ControlHandler : IInizializable
    {


        public void Inizialize()
        {
            
        }

        public void ProcessControl(InputData inputData)
        {
            if(inputData.isMoving)
            {
                Vector3 delta = inputData.Position - inputData.PreviousPosition;
                World.Instance.Current.CreateEntityWith<CameraMoveEvent>().Delta = delta;
            }

            if(inputData.Phase == TouchPhase.Ended)
            {

            }
        }

        private void ProcessTap(InputData inputData)
        {
            RaycastHit hit;
            //Vector3 dir = Camera.main.ScreenToWorldPoint(
            //    );

            //if(Physics.Raycast()
        }
    }
}