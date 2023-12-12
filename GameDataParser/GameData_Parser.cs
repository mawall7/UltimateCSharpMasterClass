using CookiesCookbook.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameDataParser
{
    public class GameData_Parser : IGameData_Parser
    {
        public List<Model> ParseGameFileToModel(string data, string filenameinput)
        {
            try
            {
                return JsonSerializer.Deserialize<List<Model>>(data);
            }
            catch(JsonException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"JSON in the {filenameinput} was not in a valid format.\n" +
                   $"JSON body:{data}"
                    );
                Console.ForegroundColor = ConsoleColor.White;
                throw new InvalidJsonFormatException(filenameinput);
            }

        }
    }

}
     
