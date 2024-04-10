using System;
using System.Collections.Generic;

namespace EnumerableExtensions
{
    public static class EnumerableExtensions
    {
        public static int SumOfEvenNumbers(this IEnumerable<int> numbers)
        {
            //return 1;
            int sum = 0;
            foreach (var number in numbers)
            {
                if (number % 2 == 0)
                {
                    sum += number;
                }
            }
            return sum;
        }
    }
}
