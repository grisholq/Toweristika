namespace Toweristika.Other
{
    public class Timer
    {
        private float last;
        private float period;       

        public Timer(float period, float last)
        {
            this.period = period;
            this.last = last;
        }

        public bool IsPassed(float time)
        {
            return (time - last) >= period;
        }

        public void Update(float time)
        {
            last = time;
        }
    }
}