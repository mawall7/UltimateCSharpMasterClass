using System;
using System.IO;


namespace GameDataParser
{
    public class consoleui : IUi
    {


        private string _userinput;
        private readonly IGameData_Parser _gameparser;
        private readonly IGameFileReader _filerepository;
        private readonly IUi _ui;

        public consoleui(IGameFileReader filerepository, IGameData_Parser gameparser)
        {
            _filerepository = filerepository;
            _gameparser = gameparser;
            
           
        }
        public void Exit()
        {
            Console.WriteLine("Press any key to close" + Environment.NewLine);
            
        }

        public void PrintGameData() //flyttas till en egen klass så att PrintGameDataklassen tar en IFileReader istället det är ju ingen GameFileReader heller utan borde ändra namn till FileReader medan PrintGameFile klassen kan kallas så eftersom den tar en VideoGameModel.
        {
            try
            {
                var stringdata = _filerepository.ReadFile(_userinput); //flyttas eftersom PrintGameData bara ska skriva ut gamedata den kan också ta en IUI för att skriva ut
                var parseddata = _gameparser.ParseGameFileToModel(stringdata,_userinput);//kan flyttas av samma anledning
                
                Console.WriteLine("\nLoaded games are:");
                foreach (VideoGameModel model in parseddata)
                {
                    Console.WriteLine($"{model.Title}, released in {model.ReleaseYear}, rating: {model.Rating}" + Environment.NewLine);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File not found");
            }
           
        }

        public void ReadInput()
        {
            _userinput = Console.ReadLine();
      
            if (_userinput is null) { throw new ArgumentNullException("FileName cannot be null."); }
            else if(_userinput == "") { throw new ArgumentException("FileName cannot be empty."); }               
        }


        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintError(string errormessage)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errormessage);
            Console.ForegroundColor = originalColor;
        }
    }
}

    

   





