namespace Toweristika.Other
{
    public class Percent
    {
        private float percent;
        const float max = 100;
        const float min = 0;

        public Percent(float percent)
        {
            this.percent = percent;
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
