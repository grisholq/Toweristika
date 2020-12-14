using System;

namespace Toweristika.Other
{
    [Serializable]
    public class Range
    {
        private int min;
        private int max;

        public int Min
        {
            get
            {
                return min;
            }
        }

        public int Max
        {
            get
            {
                return max;
            }
        }
    }
}