using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCSharpMasterClass
{
    public class ValidateNumber
    {
        public bool ValidateNumberAsBool(IEnumerable<int> numbers, Func<int,bool> predicate)
        {
            foreach(var numbr in numbers)
            {
                if (!predicate(numbr))
                {
                    return false;
                }
              
            }
            return true;
        }
        
    }
}
