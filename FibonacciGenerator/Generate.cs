﻿using System;
using System.Collections.Generic;

namespace FibonacciGenerator
{
    public static class Fibonacci
    {
        public static IEnumerable<int>Generate(int n)
        {
            if(n < 0)
            {
                throw new ArgumentException($"{nameof(n)} cannot be smaller than 0. ");

            }
            const int maxValidNumber = 46;

            if(n > maxValidNumber)
            {
                throw new ArgumentException($"{nameof(n)} cannot be larger than {maxValidNumber}" +
                    $"as it will cause numeric overflow");

            }

            var result = new List<int>();
            int a = -1;
            int b = 1;
            for (int i = 0; i < n; i++)
            {
                int sum = a + b;
                result.Add(sum);
                a = b;
                b = sum;
            }
            return result;
        }
    }
}
