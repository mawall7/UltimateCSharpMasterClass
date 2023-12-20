using System;
using System.Collections.Generic;
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
            
            foreach (var item in animals)
            {
                Console.WriteLine($"MaxWeight of {item.Key.ToString()} is: {item.Value}.");
            }
            
         

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
