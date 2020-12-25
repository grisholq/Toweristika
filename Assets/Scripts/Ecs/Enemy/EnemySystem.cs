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
        private EcsFilterSingle<EnemiesManager> enemiesManagerFilter = null;
      
        private EcsFilter<EnemyRecievedDamageEvent> enemyRecievedDamageEvent = null;
        private EcsFilter<EnemyRecievedHealingEvent> enemyRecievedHealingEvent = null;
        private EcsFilter<EnemySpawnedEvent> enemySpawnedEvent = null;
        
        private EcsFilter<StartWaveEvent> startWaveEvent = null;
        private EcsFilter<WaveEndedEvent> waveEndedEvent = null;

        private EcsFilter<WavesEndedEvent> wavesEndedEvent = null;

        public void Initialize()
        {
            world.CreateEntityWith<EnemySpawner>();
            world.CreateEntityWith<EnemyWavesHandler>().Inizialize();
            world.CreateEntityWith<EnemySpawningTimer>().Inizialize();
            world.CreateEntityWith<EnemiesManager>().Inizialize();
        }

        public void Destroy()
        {

        }

        public void Run()
        {
            if (wavesEndedEvent.EntitiesCount > 0) return;

            DestroyEvents();

            if (startWaveEvent.EntitiesCount != 0) StartWave();
            else RunWave();

            RunEvents();
        }

        private void StartWave()
        {
            EnemySpawner spawner = enemySpawnerFilter.Data;
            EnemySpawningTimer timer = enemySpawningTimerFilter.Data;
            EnemyWavesHandler waves = enemyWavesHandlerFilter.Data;

            if (waves.IsWavesEnded)
            {
                world.CreateEntityWith<WavesEndedEvent>();
                return;
            }

            if (startWaveEvent.EntitiesCount == 0)

            spawner.SetEnemyWave(waves.GetCurrentWave());
            timer.Update();
            waves.NextWave();
        }

        private void RunWave()
        {
            EnemySpawner spawner = enemySpawnerFilter.Data;
            EnemySpawningTimer timer = enemySpawningTimerFilter.Data;
            EnemiesManager manager = enemiesManagerFilter.Data;

            if (timer.Passed)
            {
                timer.Update();
                Enemy enemy = spawner.GetEnemy();
                manager.AddEnemy(enemy);
                world.CreateEntityWith<EnemySpawnedEvent>().Enemy = enemy;             
            }

            if (spawner.IsWaveEnded)
            {
                world.CreateEntityWith<WaveEndedEvent>();
            }
        }

        private void RunEvents()
        {
            if (enemyRecievedDamageEvent.EntitiesCount != 0)
            {
                EnemyRecievedDamageEvent[] events = enemyRecievedDamageEvent.Components1;
                EnemyRecievedDamageEvent buf;
                for (int i = 0; i < enemyRecievedDamageEvent.EntitiesCount; i++)
                {
                    buf = events[i];
                    buf.Source.Damage(buf.Enemy);
                }
            }

            if (enemyRecievedHealingEvent.EntitiesCount != 0)
            {
                EnemyRecievedHealingEvent[] events = enemyRecievedHealingEvent.Components1;
                EnemyRecievedHealingEvent buf;
                for (int i = 0; i < enemyRecievedHealingEvent.EntitiesCount; i++)
                {
                    buf = events[i];
                    buf.Source.Heal(buf.Enemy);
                }
            }
        }

        private void DestroyEvents()
        {
            World.Instance.RemoveEntitiesWith<EnemyRecievedDamageEvent>();
            World.Instance.RemoveEntitiesWith<EnemyRecievedHealingEvent>();
            World.Instance.RemoveEntitiesWith<EnemySpawnedEvent>();
        }  
    }
}