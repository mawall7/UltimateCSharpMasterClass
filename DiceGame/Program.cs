using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //int tries = 3; // move to gamesession class
            //Dice dice = new(new Random());
            //DiceGameApp gamesession = new DiceGameApp(dice, new ConsoleUserCommunication());

            //GameResult gameResult = gamesession.Play();
            //gamesession.PrintResult(gameResult);

            //Console.ReadKey();

            Console.WriteLine("Main thread's ID: " + Thread.CurrentThread.ManagedThreadId);
            //task respresent a unit of work that can be exctued asynchronosly on a separate thread
            //Task task1 = Task.Run(() => PrintPlusses(200));
            //Task task2 = Task.Run(() => PrintMinuses(200));
            string userinput = default;
            //Task taskWithResult = Task.Run(() => CalculateLength("Hello there"))
            //.ContinueWith(taskWithResult => Console.WriteLine("Length is:" + taskWithResult.Result)); //ContinueWith gör att taskWithResult är nonblocking operation.
            //var list = new List<int>();
            //list.Add(1);
            //list.Add(2);
            //string numbersSeparatedByComma = String.Join(',', list); 

            //taskWithResult.Wait();

            //Console.WriteLine("Length is: " + taskWithResult.Result); //.Result is a blocking operation(of the main thread)
            //task1.Start();
            //task2.Start();
            string result = FormatSquaredNumbersFrom1To(5);
            Console.WriteLine("The numbers are" + result);
           
            do
            {
                Console.WriteLine("Enter a command");
                userinput = Console.ReadLine();

            } while(userinput!= "exit");
            
            Console.WriteLine("Program is finished");
            Console.ReadLine();


            //    while (tries > 0 ) 
            //    {

            //        var guess = gamesession.Guess();
            //        tries--;

            //        if (guess == true)
            //        {
            //            Console.WriteLine("You win");
            //            break;
            //        }
            //        if (guess == false)
            //        {
            //            Console.WriteLine("Wrong number");
            //            if (tries == 0)
            //            {
            //                Console.WriteLine("You Lose");
            //            }
            //        }
            //    }

            //    Console.ReadLine();
            //}
        }

        public static string FormatSquaredNumbersFrom1To(int n)
        {
            if(n < 0) throw new ArgumentException("an error of task occurred");
            
            Task<string> task1 = Task.Run(() =>
            {
                Thread.Sleep(2000);
                var numbers = new List<double>();
                for (int i = 1; i <= n; i++)
                {
                    double numberRaisedToTwo = Math.Pow(i, 2);
                    numbers.Add(numberRaisedToTwo);
                }
                return numbers;
            }).ContinueWith(task1 => { return String.Join(',' + " ", task1.Result);});

            return task1.Result;
        }

            static int CalculateLength(string input)
        {
            Console.WriteLine("\nCalculateLenth thread's ID: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(4000);
            return input.Length;
        }
        static void PrintPlusses(int n) 
        {
            Console.WriteLine("\nPrintPlusses thread's ID: " + Thread.CurrentThread.ManagedThreadId); 
            for(int i = 0; i <= n; i++)
            {
                Console.Write("+");
            }
        }

        static void PrintMinuses(int n)
        {
            Console.WriteLine("\nPrintMinuses thread's ID: " + Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i <= n; i++)
            {
                Console.Write("-");
            }
        }
    }
}
            
               
                
            

