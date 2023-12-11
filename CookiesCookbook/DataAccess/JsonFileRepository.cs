using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;



namespace CookiesCookbook.DataAccess
{
    public class JsonFileRepository : FileRepository
    {
        
        protected override string StringsToText(List<string> data)
        {
             return JsonSerializer.Serialize(data);  
            
        }

        protected override List<string> TextToStrings(string data)
        {
            return JsonSerializer.Deserialize<List<string>>(data);
        }
            
    }

}
            
            

