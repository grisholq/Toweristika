namespace Toweristika.Other
{
    public class Percent : ClampedValue
    {
        public float Value { get; set; }

        public Percent(float percent)
        {
            this.Value = percent;
            min = 0;
            max = 100;
        }

        public void ValueToPercent(float val, float minVal, float maxVal)
        {
            Value = val * (minVal + maxVal) / max;
        }

        public float PercentToValue(float minVal, float maxVal)
        {
            return Value * (minVal + maxVal) / max;
        }
    }
}