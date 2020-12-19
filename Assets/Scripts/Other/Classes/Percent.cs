using System;
using UnityEngine;

namespace Toweristika.Other
{
    public class Percent : ClampedValue
    {
        private float percent;

        public Percent(float percent)
        {
            this.percent = percent;
            min = 0;
            max = 100;
        }

        public void SetPercent(float val, float minVal, float maxVal)
        {
            percent = val * (minVal + maxVal) / max;
        }

        public float GetPercentValue(float minVal, float maxVal)
        {
            return percent * (minVal + maxVal) / max;
        }
    }

}
