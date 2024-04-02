using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using SimpleCalculator;
using ValidateNumberEtc;

namespace UltimateCSharpMasterClass
{
    class Program
    {
        private static List<int> _list = new List<int>() { 1, 2, 3, 4, 5, 6, 1 };
        public Calculator calculator;
        static void Main(string[] args)
        {
            var stack = new Stack<String>();
            stack.Push("fox");
            stack.Push("cat");
            stack.Push("wolf");

            var containscat = stack.DoesContainAny("wolf","cat");
            var containshorse = stack.DoesContainAny("horse");
            IList<string> ilist = new List<string>() { "a", null,"b","c" }; 
            var resultlist = YieldExercise.GetAllAfterLastNullReversed(ilist).ToList();
            int counter = 0;
            foreach(var item in YieldExercise.GetAllAfterLastNullReversed(ilist))
            {
                Console.WriteLine($"item {counter++}: {item}");
            }

            var sortedList = new List<int>()
            {1, 3, 4, 6, 11, 12, 14, 16, 18};
            var indexOf1 = sortedList.FindIndexInSorted<int>(1);
            var indexOf11 = sortedList.FindIndexInSorted<int>(11);
            var indexOf12 = sortedList.FindIndexInSorted<int>(12);
            var indexOf18 = sortedList.FindIndexInSorted<int>(18);
            var indexOf13 = sortedList.FindIndexInSorted<int>(13);

            var stringarray = new string[] { "all", "ally", "alfred", "fredric" };
            var list = stringarray.ToList();

            Console.OutputEncoding = Encoding.Unicode;
            var omega = 'Ω';
            Console.WriteLine((int)omega); 
            Console.WriteLine(omega);

            var hello = "Hello";
            Console.WriteLine(Reverse(hello));

            
            

            //CustomCollection ccollection = new CustomCollection(
            //    new string[] {"aaa", "bbb", "ccc"});
            //IEnumerator enumerator = ccollection.Words.GetEnumerator();
            //object currentobject;
            //while (enumerator.MoveNext())
            //{
            //    currentobject = enumerator.Current;
            //    Console.WriteLine(currentobject);
            //}
            //foreach (var item in ccollection)
            //{
            //    Console.WriteLine(item);
            //}
            //string choice;
            //int a, b;
            //string r;
            //string baseadress = "https://datausa.io/api/";
            //string apiendpoint = "data?drilldowns=Nation&measures=Population";
            //IApiReader reader = new ApiReader();
            //var apidata = reader.ReadAsync(baseadress, apiendpoint).Result;
            //var root = JsonSerializer.Deserialize<Root>(apidata);
            ////var rootorderfromearliesttolastyear;
            //int[] years = new int[] { 1921, 1932, 1901 };

            //var yearsaslist = years.ToList();
            //yearsaslist.Sort();
            ////Array.Reverse(years);

            //foreach (var yearlyData in root.data.OrderBy(item => item.IDYear))
            //{
            //    Console.WriteLine($"Nation: {yearlyData.Year}, Population: {yearlyData.Population}.");
            //}
            //TryWinFormsAssignment();
            //Console.ReadKey();

            //BlueConsoleWriter bluewriter = new BlueConsoleWriter(
            //    ConsoleColor.Red,
            //    new Validator()
            //    );
            //try
            //{
            //    int x = 1;
            //    string xstring = 1.ToString("0");
            //    Console.WriteLine(xstring);


            //    bluewriter.PrintInBlue(" 1 attempt to write to console");
            //}

            //catch (FormatException e)
            //{

            //    Console.WriteLine("Attempt to print was not Valid. " + e.Message);
            //}

            //var animallist = new List<Animal>()
            //{
            //    new Animal(){Animaltype = AnimalType.dog, Age = 2, Weight = 1.2},
            //    new Animal(){Animaltype = AnimalType.cat, Age = 1,Weight = 1},
            //    new Animal(){Animaltype = AnimalType.bird, Age = 3,Weight = 0.3},
            //    new Animal(){Animaltype = AnimalType.dog, Age = 5, Weight = 2.4},
            //    new Animal(){Animaltype = AnimalType.dog, Age = 10, Weight = 5.7}
            //};

            //var sorted = animallist[0].SortAscendingPropGeneric<decimal>(animallist); 
            //animallist.Sort((double) animallist.Sort<double>);

            //var animals = new Dictionary<AnimalType, double>();
            //var animals = CalculateAnimals.FindMaxWeight(animallist);

            //var numbers = new[] { 1, 2, 3, 3, 4 };

            //var multipliedbytwo = numbers.Select(number => number * 2);
            //var numbersasstring = numbers.Select(number => number.ToString());
            //IEnumerable<string> numbersasstring = numbers
            //    .Where(item => item > 1) // new collection will not contain 1
            //    .Distinct() // will only print 3 one time
            //    .Select((number, index) => $"indx = {index + 1}.{number}");

            //int count = 0;
            //foreach (string numbr in numbersasstring)
            //{

            //    //Console.WriteLine($"{numbr}, count = {count++}");
            //    Console.WriteLine(numbr);
            //}
            //Print<string>(numbersasstring);

            List<int[]> rows = new List<int[]>();
            int currentrow = 0;
            int numbersofrows = 5;

            do
            {
                rows.Add(new int[2] { 1 + currentrow, 1 + currentrow });
                currentrow++;

            } while (currentrow < numbersofrows);



            //for(int r = 0;  r < intlist.MaxRows; r++)
            //{
            //    int current_row = r + 1;
            //    Console.WriteLine("current row: " + current_row + System.Environment.NewLine);

            //    for(int c = 0; c < 2; c++)
            //    {
            //        int inttoprint = rows[r][c];
            //        Console.Write($"int32 at index{c}:{inttoprint} "+ System.Environment.NewLine);
            //    }
            //    Console.WriteLine();
            //}






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

        //public static void TryWinFormsAssignment()
        //{
        // var typesuggester = new TypeSuggester();
        //double x = 12323.23 float d = 0.23231
        //typesuggester.getSmallestType(x);
        //typesuggester.getsmallestType(d);

        //Console.WriteLine("type a value to find best type choice");
        //string uservalue = Console.ReadLine();
        //string uservaluetest = "100000";
        //BigInteger parsedvalue = default;
        //string selectedtypewithsmallestmax = default;
        //BigInteger.TryParse(uservalue, out parsedvalue); // tryparse ger 0 för float
        //if (parsedvalue != 0)
        //{
        //    parsedvalue = uservalue.ConvertFloatToString();
        //}
        //methods needed for assignment 
        //var typesuggester = new NumericsTypeSuggester();
        //while (true)
        //{
        //    Console.WriteLine(typesuggester.FindSmallestNumericType(100, -100, true, false)); // sbyte;
        //    Console.WriteLine(typesuggester.FindSmallestNumericType(100, -100, false, true)); // float;

        //    Console.WriteLine(typesuggester.FindSmallestNumericType(BigInteger.Parse("1000000000000000000000000000000000000000000000000000000000000000000000000000000000"),1000, true, false));//Big I ok

        //Console.WriteLine(typesuggester.FindSmallestNumericType(BigInteger.Parse("10000000000000000000000000000000000000000000000000000000000000000000000000000000"), -100, false, false));//double blev sbyte
        //Console.WriteLine(typesuggester.FindSmallestNumericType(BigInteger.Parse("100000000000000000000000000000000000000000000000000"), 1000, false, false));//double ok
        //Console.WriteLine(typesuggester.FindSmallestNumericType(BigInteger.Parse("10000000000000000000000000000000000"), 1000, false, false));//float blev double ok

        //Console.WriteLine(typesuggester.FindSmallestNumericType(BigInteger.Parse("1000000000000000000000000000000000000"), 1000, false, false));//float ? ok
        //Console.WriteLine(typesuggester.FindSmallestNumericType(BigInteger.Parse("1000000000000000000000000000000000000000"),1000, false, true));//impossible ? ok
        //Console.WriteLine(typesuggester.FindSmallestNumericType(BigInteger.Parse("1000000000000000000000000000000000000000000000000000000000000000000000000000000000"), 1000, false, false));//double? ok


        //    if (parsedvalue == 1) 
        //{
        //    break; 
        //}
        //}
        //var cstype = TypesSuggesterHelperClass.GetCSType(suggestedtypeasstring);
        //var nonintegraltypes = WIndowsFormAssignmentExtentions.types.
        //Where(item => item.Key == typeof(float) || item.Key == typeof(double) || item.Key == typeof(decimal));
        //var allpossibletypes = WIndowsFormAssignmentExtentions.FindAllPossibleTypes(parsedvalue);
        //var allpossibleIntegraltypes = WIndowsFormAssignmentExtentions.FindOnlyIntegralOrAll(allpossibletypes, true);
        ////var allposibleNonIntegraltypes = WIndowsFormAssignmentExtentions.FindOnlyNonIntegral(allpossibletypes);


        //Console.WriteLine("min type for" + uservalue + "is" + selectedtypewithsmallestmax);
        //Console.WriteLine("is int16 largest val smaller than int largest val?");
        //Console.WriteLine("int16:" + Int16.MaxValue + "int32:" + int.MaxValue);

        ////Console.WriteLine("double min" + double.MinValue);
        //Console.WriteLine("decimal min" + decimal.MinValue);

        public static string Reverse(string input)
        {
            var stringbuilder = new StringBuilder();
            for (int i = input.Length -1; i >= 0; i--)
            {
                stringbuilder.Append(input[i]);
            }
            return stringbuilder.ToString();
        }
    }



    //public static void Print<T>(IEnumerable<T> collection)
    //{
    //    foreach (T item in collection)
    //    {
    //        Console.WriteLine(item);
    //    }
    //}
    //Exercise 38 Count & Contains 
    //public static int CountListsContainingZeroLongerThan(
    //    int length,
    //    List<List<int>> listsOfNumbers)
    //{

    //    var result = listsOfNumbers.Count(item => item.Count() > length && item.Contains(0));

    //    return result;

    //}

    //Exercise 39
    //public static string FindShortestWord(List<string> words)
    //{
    //    if (words.Count == 0)
    //        throw new ArgumentOutOfRangeException();
    //    else
    //    {
    //        var shortestword = words.OrderBy(item => item.Count()).First();
    //        return shortestword;
    //    }
    //}

    //Exercise 40
    //public static IEnumerable<DateTime> GetFridaysOfYear(int year, IEnumerable<DateTime> dates)
    //{
    //    var fridays = dates.Where(date => date.DayOfWeek == DayOfWeek.Friday && date.Year == year).Distinct();
    //    return fridays;
    //}
    //public static string Describe(object someObject)
    //{
    //    string s = "";
    //    if (someObject is int Int)
    //    {

    //        s = $"Int of value {Int}";
    //    }
    //    if (someObject is double Double)
    //    {

    //        s = $"Double of value {Double}";
    //    }
    //    if (someObject is decimal Decimal)
    //    {

    //        s = $"Decimal of value {Decimal}";
    //    }
    //    return s;
    //}



    //public static bool IsLargerThanZero(int number)
    //{
    //    return number > 0;
    //}

    //public bool IsLargerThanTen(int number)
    //{
    //    return number > 10;
    //}
    

}

    public enum AnimalType
    {
        dog,
        cat,
        bird
    }



public class Animal : IComparable<Animal> // IComparable<Animal>
    {


        public delegate int myDelegate<T>(object obj, object source);
        
        public List<Animal> SortAscendingPropGeneric<T>(List<Animal> animals)
        {
         
            animals.Sort(animals[0].CompareTo<T>);
            return animals;
        }
             
        

        public double Weight { get; set; }
        public AnimalType Animaltype { get; set; }

        public int Age { get; set; }

       //Egna övningar

       
        public int CompareTo<T>(object obj, object target = null) //finns annat sätt att göra det genom Sort genom IComparable? svar: nej men, finns en Sort metod som tar en delegat 
        {
           
                
               
                
                var type = typeof(T);
                var animalobj = (Animal)obj;
                var values = animalobj.GetType().GetProperties();
                var selectedProperty = values.Where(prop => prop.PropertyType == typeof(T))
                    .FirstOrDefault();

                var Value = (T)selectedProperty.GetValue(obj);
                var Name = selectedProperty.Name;


                if (type == typeof(double) || type == typeof(int))
                {
                    double? val;
                    val = Value as int?;
                    double targetvalue;
                    if (type == typeof(double)) { targetvalue = Weight; }
                    else targetvalue = Age;
                    if (targetvalue < val)
                    {
                        return 1;
                    }
                    if (targetvalue > val)
                    {
                        return -1;
                    }
                    return 0;
                }

            throw new Exception("wrong type use in Compare To<T> method");
        }  
           

          
        public int CompareTo(Animal other)
        {
            if (Weight < other.Weight)
            {
                return 1;
            }
            if (Weight > other.Weight)
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

    public struct MaxMinTypeDescription : ITypeDescription
    {
        public MaxMinTypeDescription(double? max, double? min)
        {
            Max = max;
            Min = min;
        }

        public double? Max { get; }
        public double? Min { get; }

        public int CompareTo(MaxMinTypeDescription other)
        {
            if(Max > other.Max)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        
    }

    public interface ITypeDescription
    {
        public double? Max { get; }
        public double? Min { get; }
    }

    public static partial class CalculateAnimals //Coding Exercise 36 Klass som hittar maxvikt för en lista med Animals av IComparable
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

    public struct Time
    {
        public int Hour { get; }
        public int Minute { get; }

        public static int MaxHours { get; } = 24;
        public static int MaxMinutes { get; } = 60;

        public Time(int hour, int minute)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(
                    "Hour is out of range of 0-23");
            }
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentOutOfRangeException(
                    "Minute is out of range of 0-59");
            }
            Hour = hour;
            Minute = minute;
            
        }

        public override string ToString() =>
            $"{Hour.ToString("00")}:{Minute.ToString("00")}";

        public static bool operator ==(Time time1, Time time2)
        {

            if (time1.Hour.Equals(time2.Hour) && time1.Minute.Equals(time2.Minute))
            {
                return true;
            }
            return false;

        }

        public static bool operator !=(Time time1, Time time2)
        {
            
            if (!time1.Hour.Equals(time2.Hour) && !time2.Minute.Equals(time2.Minute))
            {
                
                return true;
            }
            return false;
        }

        public static int getCorrectHours(int hour, Func<int, bool> isHoursLargerthanMaxHours)
        {
            //throw new NotImplementedException();
            if (isHoursLargerthanMaxHours(hour))
            {
                return hour - MaxHours;
            }
            return hour;
                   
         }
        public static Time getCorrectMinutes(Time time1, Time time2, Func<bool> isMinutesLargerThanMaxMinutes)
        {
            int minutes = time1.Minute + time2.Minute;
            
            if (isMinutesLargerThanMaxMinutes())
            {
                return new Time( time1.Hour + 1, minutes - MaxMinutes);
            }
            
            else return new Time(time1.Hour, minutes); 
        }

        public static Time operator +(Time time1, Time time2)
        {
            int Hours = 0;
            int Minutes = 0;
            int hoursSum = time1.Hour + time2.Hour;
            //int hoursDif = hoursSum - 24;
            Hours = getCorrectHours(hoursSum, (hours) => hoursSum > MaxHours);
            var newtime = getCorrectMinutes(time1, time2, () => time1.Minute + time2.Minute > 60) ;

              
            
            return newtime;
        }
    }
    public record WeatherData(decimal Temperature, int Humidity);

    //public static void setWeatherData(WeatherData data)
    //{
    //    var weatherdata = new WeatherData(25.1m, 65);
    //    var newwatherdatanondestructivemutation = weatherdata with { Temperature = 23.1m, Humidity = 33 };

    //}
    public record Annotations(
           [property: JsonPropertyName("source_name")] string source_name,
           [property: JsonPropertyName("source_description")] string source_description,
           [property: JsonPropertyName("dataset_name")] string dataset_name,
           [property: JsonPropertyName("dataset_link")] string dataset_link,
           [property: JsonPropertyName("table_id")] string table_id,
           [property: JsonPropertyName("topic")] string topic,
           [property: JsonPropertyName("subtopic")] string subtopic
       );

    public record Datum(
        [property: JsonPropertyName("ID Nation")] string IDNation,
        [property: JsonPropertyName("Nation")] string Nation,
        [property: JsonPropertyName("ID Year")] int IDYear,
        [property: JsonPropertyName("Year")] string Year,
        [property: JsonPropertyName("Population")] int Population,
        [property: JsonPropertyName("Slug Nation")] string SlugNation
    );

    public record Root(
        [property: JsonPropertyName("data")] IReadOnlyList<Datum> data,
        [property: JsonPropertyName("source")] IReadOnlyList<Source> source
    );

    public record Source(
        [property: JsonPropertyName("measures")] IReadOnlyList<string> measures,
        [property: JsonPropertyName("annotations")] Annotations annotations,
        [property: JsonPropertyName("name")] string name,
        [property: JsonPropertyName("substitutions")] IReadOnlyList<object> substitutions
    );
//}
