using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser
{
    public static class Extentions 
    {
        public static void FormatJsonException(this Exception exception, string filenameinput, string data)
        {
            Console.ForegroundColor = ConsoleColor.Red;
           
            Console.WriteLine($"JSON in the {filenameinput} was not in a valid format.\n" +
               $"JSON body:{data}"
                );
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
