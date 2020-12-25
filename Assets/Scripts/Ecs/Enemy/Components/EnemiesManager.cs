using System;
using System.Collections.Generic;
using Toweristika.Other;

namespace Toweristika.Ecs
{
    public class EnemiesManager : IInizializable
    {
        private List<Enemy> enemies;

        public int Count
        {
            get
            {
                return enemies.Count;
            }
        }

        public void Inizialize()
        {
            enemies = new List<Enemy>();
        }

        public void AddEnemy(Enemy enemy)
        {
            enemies.Add(enemy);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            enemies.Remove(enemy);
        }

        public Enemy GetEnemy(int index)
        {
            return enemies[index];
        }

        public void RemoveAll(Predicate<Enemy> predicate)
        {
            enemies.RemoveAll(predicate);
        }
    }
}