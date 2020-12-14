using System;
using UnityEngine;

namespace Toweristika.Other
{
    [Serializable]
    public class Range
    {
        [SerializeField] private float min;
        [SerializeField] private float max;

        public float Min
        {
            get
            {
                return min;
            }
        }

        public float Max
        {
            get
            {
                return max;
            }
        }

        public float Clamp(float val)
        {
            return Mathf.Clamp(val, min, max);
        }

        public bool InRange(float val)
        {
            return val <= max && val >= min;
        }
    }
}