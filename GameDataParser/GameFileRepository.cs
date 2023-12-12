using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CookiesCookbook.DataAccess;
namespace GameDataParser
{
    public class GameFileRepository : IGameFileRepository
    {
        
        public string ReadFile(string path)
        {
            
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
                
            }
            throw new FileNotFoundException();
        }
       
           
           

    }
       
}
