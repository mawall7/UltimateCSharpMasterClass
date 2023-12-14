using System;


namespace GameDataParser
{
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
                    _ui.ReadInput(); //nakdelen med att inte returnera input i klassen är att hanteringen av input inte kan ske här istället sker nu hanteringen med if satser där vi skickar undanta också skriver ut message det borde ha gjorts här.
                                     
                    _ui.PrintGameData();
                  
                }
             
                catch(ArgumentNullException e) //kan refaktureras till if satser
                {
                    _ui.PrintError(e.Message);
                    _logger.AddMessage(e.Message, e.StackTrace.ToString());
                    
                }
                catch(ArgumentException e)
                {
                    _ui.PrintError(e.Message);
                    _logger.AddMessage(e.Message, e.StackTrace);
                }
                
                catch(Exception)
                {
                    _ui.PrintError("Sorry! The application has experienced an unexpected error and will have to be closed.");
                    exit = true;
                }
            } while (!exit);
                
            _ui.Exit();
        }
    }
}

    

   





