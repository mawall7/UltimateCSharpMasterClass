using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateNumberEtc
{
    public static class ListExtensions
    {
        //Binary Search
        public static int? FindIndexInSorted<T>(
            this IList<T> list,  T itemToFind) where T : IComparable<T>
        {
            int leftBound = 0;
            int rightBound = list.Count - 1;
            while (leftBound <= rightBound)
            {
                int middleIndex = (leftBound + rightBound) / 2;
                if (itemToFind.Equals(list[middleIndex]))
                {
                    return middleIndex;
                }
                else if (itemToFind.CompareTo(list[middleIndex]) < 0)
                {
                    rightBound = middleIndex - 1;
                    --middleIndex;
                }
                else
                {
                    leftBound = middleIndex + 1;
                }
            }
            return null;
        }

        
    }
}
