using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDataAggregator.FileAccess
{
    public interface IReader
    {
        public string ReadAsString(string path);
    }
}
