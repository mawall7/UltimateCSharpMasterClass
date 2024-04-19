using System;
using System.Collections.Generic;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //int tries = 3; // move to gamesession class
            Dice dice = new(new Random());
            Game gamesession = new Game(dice);
          
            GameResult gameResult = gamesession.Play();
            Game.PrintResult(gameResult);

            Console.ReadKey();




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
    }
}
            
               
                
            

