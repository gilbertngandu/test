using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceLayer.Service
{
    public class CommonFactorService
    {
        public int highestCommonFactor(int[] numbers)
        {
            return numbers.Aggregate(highestCommonFactor);
        }

        int highestCommonFactor(int a, int b)
        {
            return b == 0 ? a : highestCommonFactor(b, a % b);
        }
    }
}
