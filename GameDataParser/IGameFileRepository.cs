using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParser
{
    public interface IGameFileRepository
    {
        public string ReadFile(string path);
    }
}
