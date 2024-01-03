using System;
using System.Collections.Generic;
using System.Linq;
using SimpleCalculator;

namespace UltimateCSharpMasterClass
{
    class Program
    {
        private static List<int> _list = new List<int>() {1,2,3,4,5,6,1};
        public Calculator calculator;
        static void Main(string[] args)
        {
            //string choice;
            //int a, b;
            //string r;

            var animallist = new List<Animal>()
            {
                new Animal(){Animaltype = AnimalType.dog, Weight = 1.2},
                new Animal(){Animaltype = AnimalType.cat, Weight = 1},
                new Animal(){Animaltype = AnimalType.bird, Weight = 0.3},
                new Animal(){Animaltype = AnimalType.dog, Weight = 2.4},
                new Animal(){Animaltype = AnimalType.dog, Weight = 5.7}
            };

            
            //var animals = new Dictionary<AnimalType, double>();
            var animals = CalculateAnimals.FindMaxWeight(animallist);

            var numbers = new[] { 1, 2, 3, 3, 4 };

            //var multipliedbytwo = numbers.Select(number => number * 2);
            //var numbersasstring = numbers.Select(number => number.ToString());
            IEnumerable<string> numbersasstring = numbers
                .Where(item => item > 1) // new collection will not contain 1
                .Distinct() // will only print 3 one time
                .Select((number, index) => $"indx = {index + 1}.{number}");

            int count = 0;
            //foreach (string numbr in numbersasstring)
            //{

            //    //Console.WriteLine($"{numbr}, count = {count++}");
            //    Console.WriteLine(numbr);
            //}
            Print<string>(numbersasstring);

            //Exercise 38
            //var ar = new List<List<int>> { new List<int>{ 1 }, new List<int> { 1, 0 }, new List<int> { 1, 0, 0 } };
            //int length = 1;
            //var result = CountListsContainingZeroLongerThan(1, ar);
            //Console.WriteLine(result);
            //foreach (var item in animals)
            //{
            //    Console.WriteLine($"MaxWeight of {item.Key.ToString()} is: {item.Value}.");
            //}
            //#Exercise 39
            //var words = new List<string> { "aaa", "b", "c", "dd" };
            //var words = new List<string>();

            //try
            //{
            //    var shortestword = FindShortestWord(words);
            //    Console.WriteLine("Shortest: " + shortestword);

            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine($"{e.Message}. The List was empty, Program interrupted");
            //    Console.ReadKey();
            //    throw; // eller throw ex
            //}//Exercise 213


            //var day = DateTime.Now; DayOfWeek dayresult = day.DayOfWeek;

            //var years = new List<DateTime>() { DateTime.Now, new DateTime(2022, 3, 31), new DateTime(2023, 3, 31), new DateTime(2023, 3, 24)};
            //var fridays = GetFridaysOfYear(2023,years);
            //foreach(var DateTime in fridays)
            //{
            //    Console.WriteLine($"{DateTime.Day}.{DateTime.Month}.{DateTime.Year}({DateTime.DayOfWeek})"); 
            //}
            //Console.WriteLine();

            //Exercise
            //ValidateNumber validator = new ValidateNumber();
            //var isnumberspositive = validator.ValidateNumberAsBool(_list, n => n > 10);
            //Console.WriteLine($"It is {isnumberspositive} that all numbers in list are positive");
            //Calculator calculator = new Calculator();
            //Console.WriteLine("Write value 1");
            //int.TryParse(Console.ReadLine(), out a);
            //Console.WriteLine("Write value 2");
            //int.TryParse(Console.ReadLine(), out b);


            //do
            //{
            //    Console.WriteLine("Make a choice");
            //    Console.WriteLine("[A]ddition\n[S]ubtraction\n[M]ultiplication\n");
            //    r = Console.ReadLine();
            //    if (!string.IsNullOrEmpty(r))
            //        r = r.ToLower();
            //} while (string.IsNullOrEmpty(r) && r!= "a" && r != "s" && r != "m");

            //var result = calculator.Sum(a, b);
            //Console.WriteLine(calculator.Calculationmessage(result));
            //calculator.SumFunc(a,b);
            //    Console.WriteLine("sum is" + calculator.GiveCalculation(a, b, (a, b) => a + b) ); 
            //    Console.ReadLine();
            //    switch (r)
            //    {
            //        case "a": 
            //            Console.WriteLine("sum is" + calculator.GiveCalculation(a, b, (a, b) => a + b));
            //        break;

            //        case "s":
            //            Console.WriteLine("difference is" + calculator.GiveCalculation(a, b, (a, b) => a - b));
            //        break;

            //        case "m":
            //            Console.WriteLine("product is" + calculator.GiveCalculation(a, b, (a, b) => a * b));
            //            break;
            //    }            
            ////Coding Exercise 24 Numeric Types Describer
            //Console.WriteLine(Describe("s"));
            //Console.WriteLine(Describe(1.12345677778898));
            //Console.WriteLine(Describe(1));
            //Console.ReadLine();
        }

        public static void Print<T>(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }
        }
        //Exercise 38 Count & Contains 
        public static int CountListsContainingZeroLongerThan(
            int length,
            List<List<int>> listsOfNumbers)
        {

            var result = listsOfNumbers.Count(item => item.Count() > length && item.Contains(0));

            return result;

        }

        //Exercise 39
        public static string FindShortestWord(List<string> words)
        {
            if (words.Count == 0)
                throw new ArgumentOutOfRangeException();
            else
            {
                var shortestword = words.OrderBy(item => item.Count()).First();
                return shortestword;
            }
        }

        //Exercise 40
        public static IEnumerable<DateTime> GetFridaysOfYear(int year, IEnumerable<DateTime> dates)
        {
            var fridays = dates.Where(date => date.DayOfWeek == DayOfWeek.Friday && date.Year == year).Distinct();
            return fridays;
        }
        public static string Describe(object someObject)
        {
            string s = "";
            if (someObject is int Int)
            {

                s = $"Int of value {Int}";
            }
            if (someObject is double Double)
            {

                s = $"Double of value {Double}";
            }
            if (someObject is decimal Decimal)
            {

                s = $"Decimal of value {Decimal}";
            }
            return s;
        }



        public static bool IsLargerThanZero(int number)
        {
            return number > 0;
        }

        public bool IsLargerThanTen(int number)
        {
            return number > 10;
        }

    }

    public enum AnimalType
    {
        dog,
        cat,
        bird
    }
    public class Animal : IComparable<Animal>
    {
        public double Weight { get; set; }
        public AnimalType Animaltype { get; set; }

        public int CompareTo(Animal other)
        {
           if(Weight < other.Weight)
            {
                return 1;
            }
           if(Weight > other.Weight)
            {
                return -1;
            }
            return 0;
        }

        public override string ToString()
        {
            return $"Animal weight is:{Weight} of animaltype{Animaltype}";
        }

       

    }
    public static class CalculateAnimals //Coding Exercise 36 Klass som hittar maxvikt för en lista med Animals av IComparable
    {
        public static Dictionary<AnimalType, double> FindMaxWeight(List<Animal> animals)   
        {
            //var animaldict = new Dictionary<AnimalType, List<Animal>>();
            var resultdict = new Dictionary<AnimalType, double>();
            var animalTypesDict = AnimalDictPerAnimalType(animals);
                
            foreach(var animalType in animalTypesDict)
            {
                double MaxWeight = default;

                foreach(var Animal in animalType.Value)
                {
                    if(Animal.Weight > MaxWeight)
                    {
                        MaxWeight = Animal.Weight;
                    }
                }
                resultdict[animalType.Key] = MaxWeight;
                     
                
                //alternativ:
                //if (!resultdict.ContainsKey(item.Key))
                //{
                //    var max = animaldict[item.Key]; max.Sort(); //must implement IComparable
                //    resultdict[item.Key] = max[0].Weight;
                //}
            }
            return resultdict;
        }

        public static Dictionary<AnimalType, List<Animal>> AnimalDictPerAnimalType(List<Animal> animals)
        {
            var animaldict = new Dictionary<AnimalType, List<Animal>>();
            
            foreach (var animal in animals)
            {
                AnimalType animaltype = animal.Animaltype;
                if (!animaldict.ContainsKey(animaltype))
                {
                    animaldict[animaltype] = new List<Animal>();
                }
                animaldict[animaltype].Add(animal);
            }
            return animaldict;
        }

       


        

    }
        
}
