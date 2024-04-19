using DiceGame.UserCommunication;
using System;

namespace DiceGame
{

    public class Game
    {
        public readonly IDice _dice;

        private IUserCommunication _userCommunication;

        private int _tries = 3;

        public int _result { get; set; }
        public Game(IDice dice, IUserCommunication userCommunication)
        {
            _dice = dice;
            _userCommunication = userCommunication;
        }

        public bool IsRightGuess(int guess)
        {
            return guess.Equals(_result) ? true : false;
        }
        public GameResult Play()
        {
            _result = _dice.Roll();

            _userCommunication.ShowMessage(String.Format(Resource.DiceRolledMessage,_tries));

            while (_tries > 0)
            {

                var guess = _userCommunication.ReadInteger(Resource.EnterNumberMessage);
                _tries--;

                if (IsRightGuess(guess))
                {
                    
                    return GameResult.Victory;
                }
                else 
                {
                    _userCommunication.ShowMessage("Wrong number");
                }
            }
                return GameResult.Loss;
        }
        
        public void PrintResult(GameResult gameResult)
        {
            string message = gameResult == GameResult.Victory ? "You win" : "You loose";
            _userCommunication.ShowMessage(message);
        }
        
                    

            
    }
}



