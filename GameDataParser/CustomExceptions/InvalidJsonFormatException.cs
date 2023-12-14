using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser
{
    class InvalidJsonFormatException :Exception
    {
        public string FileName { get; set; }
        public InvalidJsonFormatException()
        {

        }
        public InvalidJsonFormatException(string message): base(message)
        {

        }
        public InvalidJsonFormatException(string message, Exception innerException) : base(message)
        {

        }
        public InvalidJsonFormatException(string message, string filename) : base(message)
        {
            FileName = filename;
        }

        public InvalidJsonFormatException(string message, Exception innerException, string filename) : base(message)
        {
            FileName = filename;
        }
    }
}
