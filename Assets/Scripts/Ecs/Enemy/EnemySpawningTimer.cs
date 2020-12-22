using UnityEngine;
using Toweristika.Other;
using Toweristika.Storage;

namespace Toweristika.Ecs
{
    public class EnemySpawningTimer : IInizializable
    {
        private Timer timer;

        public bool Passed
        {
            get
            {
                return timer.IsPassed(Time.time);
            }
        }

        public void Inizialize()
        {
            float period = StorageFacility.Instance.GetStorageByType<EnemySettings>().SpawnPause;
            timer = new Timer(period, Time.time);
        }

        public void Update()
        {
            timer.Update(Time.time);
        }
    }
}