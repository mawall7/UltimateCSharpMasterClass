using System;

namespace DiceGame
{
    public class Game
    {
        public readonly Dice _dice;

        private int _tries = 3;

        public int _result { get; set; }
        public Game(Dice dice)
        {
            _dice = dice;
        }

        //public void PlayDice()
        //{
        //    _result = _dice.Roll();
        //    Console.WriteLine($"Dice rolled. Guess what number it shows in {_tries} tries.");

        //}

        //public bool Guess() //Refactor to Separate ReadMethod
        //{

        //    int guess = default;
        //    string guesstring = default;

        //    Console.WriteLine("Make a guess");
        //    do
        //    {
        //        guesstring = Console.ReadLine();
        //    }
        //    while (int.TryParse(guesstring, out guess) == false);

        //    return guess.Equals(_result) ? true : false;
        //}

        public bool IsRightGuess(int guess)
        {
            return guess.Equals(_result) ? true : false;
        }
        public GameResult Play()
        {
            _result = _dice.Roll();
            Console.WriteLine($"Dice rolled. Guess what number it shows in {_tries} tries.");

            while (_tries > 0)
            {

                //var guess = Guess();
                var guess = ConsoleReader.ReadInteger("Enter a number");
                _tries--;

                if (IsRightGuess(guess))
                {
                    
                    return GameResult.Victory;
                }
                else 
                {
                    Console.WriteLine("Wrong number");
                }
            }
                return GameResult.Loss;
        }
        
        internal static void PrintResult(GameResult gameResult)
        {
            string message = gameResult == GameResult.Victory ? "You win" : "You loose";
            Console.WriteLine(message);
        }
        
                    

            
    }
}



