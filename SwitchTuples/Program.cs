using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            TwoItems<int, string> items = new(1, "test");
           
            var switchedtuple = SwapTuple.SwapTupleItems<int, string>(items);
            var iterable = switchedtuple.ToIEnumerable();
        
                foreach (var item in iterable)
                {
                    Console.WriteLine(item);
                }
        }
    }
            
          
    public static class SwapTuple
    {
        public static TwoItems<T2, T1> SwapTupleItems<T1, T2>(TwoItems<T1, T2> twoItem)
        {
             TwoItems<T2, T1> switchedtwoItems = new TwoItems<T2, T1>(twoItem.Second, twoItem.First);
           
             return switchedtwoItems;
        }
        
        
    }

    public class TwoItems<T1, T2> 
    {
        public T1 First { get; private set; }
        public T2 Second { get; private set; }

        public TwoItems(T1 first, T2 second)
        {
            First = first;
            Second = second;
        }

        public override string ToString()
        {
            return $"First:{First}, Second:{Second}";
        }

        public IEnumerable<string> ToIEnumerable()
        {
            var iterator = new List<string> { First.ToString(), Second.ToString() };
            return iterator;
        }
        

    }
}
    



    

