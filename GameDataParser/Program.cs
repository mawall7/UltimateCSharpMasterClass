using System.Collections.Generic;
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
                        new GameFileReader(), new GameData_Parser()),
                        new GameData_Parser(),
                        new GameLogger(new GameFileReader(), path));
                application.Run();
        }
    }
}

    

   





