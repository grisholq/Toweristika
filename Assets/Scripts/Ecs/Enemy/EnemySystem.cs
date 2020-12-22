using UnityEngine;
using LeopotamGroup.Ecs;

namespace Toweristika.Ecs
{
    [EcsInject]
    public class EnemySystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsWorld world = null;

        private EcsFilterSingle<EnemySpawner> enemySpawnerFilter = null;
        private EcsFilterSingle<EnemyWavesHandler> enemyWavesHandlerFilter = null;
        private EcsFilterSingle<EnemySpawningTimer> enemySpawningTimerFilter = null;
        private EcsFilterSingle<EnemyWaveState> enemyWaveStateFilter = null;


        private EcsFilter<EnemiesWavesEndedEvent> enemiesWavesEndedEvent = null;

        public void Initialize()
        {
            world.CreateEntityWith<EnemySpawner>();
            world.CreateEntityWith<EnemyWavesHandler>().Inizialize();
            world.CreateEntityWith<EnemySpawningTimer>().Inizialize();
            world.CreateEntityWith<EnemyWaveState>().State = WaveState.NoWave;
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            if (enemiesWavesEndedEvent.EntitiesCount > 0) return;

            EnemySpawner spawner = enemySpawnerFilter.Data;
            EnemyWavesHandler waves = enemyWavesHandlerFilter.Data;
            EnemySpawningTimer timer = enemySpawningTimerFilter.Data;

            EnemyWaveState state = enemyWaveStateFilter.Data;

            switch (state.State)
            {
                case WaveState.NoWave:
                    OnNoWave();                    
                    break;

                case WaveState.Going:
                    OnWaveGoing();
                    break;

                case WaveState.Ended:
                    break;
            }
        }

        private void OnNoWave()
        {
            EnemySpawner spawner = enemySpawnerFilter.Data;
            EnemyWavesHandler waves = enemyWavesHandlerFilter.Data;

            if (waves.IsWavesEnded)
            {
                world.CreateEntityWith<EnemiesWavesEndedEvent>();
                return;
            }

            spawner.SetEnemyWave(waves.GetCurrentWave());
            waves.NextWave();
        }

        private void OnWaveGoing()
        {
            EnemySpawner spawner = enemySpawnerFilter.Data;
            EnemyWavesHandler waves = enemyWavesHandlerFilter.Data;
            EnemySpawningTimer timer = enemySpawningTimerFilter.Data;



        }

        private void OnWaveEnd()
        {

        }

        private void RunEvents()
        {
            
        }
    }
}