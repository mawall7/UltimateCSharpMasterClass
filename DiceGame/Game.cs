using System;

namespace DiceGame
{
    public class Game
    {
        public readonly Dice _dice;

        public int _result { get; set; }
        public Game(Dice dice)
        {
            _dice = dice;
        }

        public void Start()
        {
            _result = _dice.Roll();
        }

        public bool Guess()
        {
            int guess = default;
            string guesstring = default;
            
            Console.WriteLine("Make a guess");
           
            do
            {
                guesstring = Console.ReadLine();
            } 
            while(int.TryParse (guesstring, out guess) == false );

            return guess.Equals(_result)? true : false;
        }
    }
}