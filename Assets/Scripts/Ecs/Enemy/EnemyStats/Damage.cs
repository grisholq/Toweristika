using System;
using UnityEngine;
using Toweristika.Other;

namespace Toweristika.Ecs
{
    [Serializable]
    public class Damage
    {
        [SerializeField] private float damage;
        [SerializeField] private DamageType damageType;

        public float Value
        {
            get
            {
                return damage;
            }

            set
            {
                damage = value;
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