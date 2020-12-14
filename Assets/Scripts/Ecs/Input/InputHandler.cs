using UnityEngine;
using Toweristika.Other;
using Toweristika.Storage;

namespace Toweristika.Ecs  
{
    public class InputHandler : IInizializable
    {
        private IInputProcessor inputProcessor;
        private InputSettings settings; 

        public void Inizialize()
        {
            inputProcessor = Application.isEditor ? new MouseInputProcessor() as IInputProcessor : new TouchInputProcessor() as IInputProcessor;
            settings = StorageFacility.Instance.GetStorageByType<InputSettings>();
        }

        public void ProcessInput(InputData inputData)
        {
            inputProcessor.ProcessInput(inputData);

            float mag = (inputData.Position - inputData.StartPosition).magnitude;
            inputData.isMoving = mag >= settings.MoveDistance;
        }
    }
}