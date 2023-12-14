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
        public List<VideoGameModel> ParseGameFileToModel(string data, string filenameinput)
        {
            
            try
            {
                return JsonSerializer.Deserialize<List<VideoGameModel>>(data);
            }
            catch(JsonException e)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"JSON in the {filenameinput} was not in a valid format.\n" +
                   $"JSON body:{data}"
                    );
                Console.ForegroundColor = ConsoleColor.White;
                throw new InvalidJsonFormatException(filenameinput);
            }

        }
        public string ParseGameFileToJson(VideoGameModel gamedata, string filename)
        {
            try
            {
                var dataserialized = JsonSerializer.Serialize(gamedata);
                return dataserialized;
            }
            catch(JsonException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"gamedata model was not in a valid format and could not be parsed to json.\n" +
                   $"model body:{String.Join(',', gamedata)}"
                    ); 
                Console.ForegroundColor = ConsoleColor.White;

                throw new InvalidJsonFormatException(filename);
            }

        }
            
            
    }

}
     
