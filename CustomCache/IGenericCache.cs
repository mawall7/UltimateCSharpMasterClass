using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache
{
    public interface IGenericCache
    {
        public bool HasData(object key);
    }
}
