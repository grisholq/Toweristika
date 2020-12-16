using System;
using UnityEngine;
using Toweristika.Other;

namespace Toweristika.Ecs
{
    [Serializable]
    public class Resistance
    {
        [SerializeField] private Percent percent;
        [SerializeField] private DamageType damageType;

        public Percent Percent 
        {
            get
            {
                return percent;
            }

            set
            {
                percent = value;
            }
        }

        public DamageType DamageType
        {
            get
            {
                return damageType;
            }

            set
            {
                damageType = value;
            }
        }
    }
}