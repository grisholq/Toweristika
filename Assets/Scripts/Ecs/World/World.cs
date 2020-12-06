using UnityEngine;
using LeopotamGroup.Ecs;

namespace MyGame
{
    public class World : MonoBehaviour
    {
        private EcsWorld world;
        private EcsSystems systems;

        private void Awake()
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);
            systems.Initialize();
        }

        private void Update()
        {
            systems.Run();
        }
    }
}