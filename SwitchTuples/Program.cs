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
            var switchedtuple = SwapTuple.SwapTupleItems<int, string>(items); //det är bättre om twotuple är en ienumerable, blir renare kod om twoitems även är en ienumerable, å andra sidan kanske den inte borde vara det då en inbyggd tuple eller är det en förbättring? ur minnessynpunkt ite. 

            Tuple<string, int> mytuple = new("hello", 1);
            string t = mytuple.ToString();
            Console.WriteLine(t);

            foreach (var item in switchedtuple)
            {
                Console.WriteLine(item);
            }

            var floats = new TwoItems<float, int>(0.4f, 2);
            var result = SwapTuple.SwapTupleItems<float, int>(floats);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }

           


    public class SwapTuple
    {

        //public static TwoItems<T2, T1> SwapTupleItems<T1, T2>(TwoItems<T1, T2> twoItem)
        //{
        //    TwoItems<T2, T1> switchedtwoItems = new TwoItems<T2, T1>(twoItem.Second, twoItem.First);

        //    return switchedtwoItems;
        //}
        public static IEnumerable<string> SwapTupleItems<T1, T2>(TwoItems<T1, T2> twoItem)
        {
            TwoItems<T2, T1> switchedtwoItems = new TwoItems<T2, T1>(twoItem.Second, twoItem.First);

            return switchedtwoItems.Printable;
        }

    }
      



    public class TwoItems<T1, T2>
    {
        public List<string> Printable
        {
            get
            {
                return new List<string> { First.ToString(), Second.ToString() };
            }
            private set
            {
                Printable = value; 
            }
        }
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

        //public IEnumerable<string> ToIEnumerable()
        //{
        //    return new List<string>() { First.ToString(), Second.ToString() };

        //}

    }
}


    



    

