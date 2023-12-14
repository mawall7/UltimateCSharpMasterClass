using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser
{
    public interface ILogger
    {
        public void AddMessage(string message, string stackTrace);

    }
            
}
