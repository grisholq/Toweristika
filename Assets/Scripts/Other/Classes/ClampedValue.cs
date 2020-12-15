using System;
using UnityEngine;

namespace Toweristika.Other
{
    [Serializable]
    public class ClampedValue
    {
        [SerializeField] protected float min;
        [SerializeField] protected float max;
    }
}