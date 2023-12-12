using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser
{
    public interface IGameData_Parser
    {
        public List<Model> ParseGameFileToModel(string data, string filenameinput);
    }
      
}
