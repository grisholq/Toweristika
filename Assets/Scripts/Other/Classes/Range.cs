using System;
using UnityEngine;

namespace Toweristika.Other
{
    [Serializable]
    public class Range : ClampedValue
    {
        public float Min
        {
            get
            {
                return min;
            }

            set
            {
                min = value;
            }
        }

        public float Max
        {
            get
            {
                return max;
            }

            set
            {
                max = value;
            }
        }

        public float Clamp(float val)
        {
            return Mathf.Clamp(val, min, max);
        }

        public bool IsClamped(float val)
        {
            return val <= max && val >= min;
        }
    }
}