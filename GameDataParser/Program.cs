using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CookieCookbook.FileAccess;
using CookiesCookbook.DataAccess;


namespace GameDataParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var metadata = new FileMetaData("gamelogger", CookiesCookbook.FileAccess.FileFormat.Text);
            string path = metadata.ToPath();
            var application = new App(
                new consoleui(
                    new GameFileRepository(), new GameData_Parser()),
                    new GameData_Parser(),
                    new GameLogger(new GameFileRepository(), path));
            application.Run();
        }
    }

    public class consoleui : IUi
    {


        private string _userinput;
        private readonly IGameData_Parser _gameparser;
        private readonly IGameFileRepository _filerepository;
       

        public consoleui(IGameFileRepository filerepository, IGameData_Parser gameparser)
        {
            _filerepository = filerepository;
            _gameparser = gameparser;
           
        }
        public void Exit()
        {
            Console.WriteLine("Press any key to close");
            Console.ReadLine();
        }

        public void PrintGameData()
        {
            try
            {
                var stringdata = _filerepository.ReadFile(_userinput);
                var parseddata = _gameparser.ParseGameFileToModel(stringdata,_userinput);
                
                Console.WriteLine("\nLoaded games are:");
                foreach (Model model in parseddata)
                {
                    Console.WriteLine($"{model.Title}, released in {model.ReleaseYear}, rating: {model.Rating}\n");
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
    }

    public interface IUi
    {
        public void ShowMessage(string message);
        public void Exit();
        public void ReadInput();
        public void PrintGameData();
    }

    public class App
    {
        private readonly IUi _ui;
        private readonly IGameData_Parser _parser;
        private readonly ILogger _logger;
        public App(IUi ui, IGameData_Parser parser, ILogger logger)
        {
            _ui = ui;
            _parser = parser;
            _logger = logger;
        }

        public void Run()
        {
            var exit = false;
            do
            {
                _ui.ShowMessage("Enter the name of the file you want to read");
                try
                {
                    _ui.ReadInput();
                    //_ui.ParseData() ev. flyttas hit? är Singleresponsibility principle för PrintGameData uppfylld ?  
                    _ui.PrintGameData();
                }
                catch(ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                    _logger.AddMessage(e.Message, e.StackTrace.ToString());
                    
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    _logger.AddMessage(e.Message, e.StackTrace);
                }
                
                catch(Exception e)
                {
                    Console.WriteLine("Sorry! The application has experienced an unexpected error and will have to be closed.");
                    exit = true;
                }
            } while (!exit);
                
            _ui.Exit();
        }
    }
}

    

   





