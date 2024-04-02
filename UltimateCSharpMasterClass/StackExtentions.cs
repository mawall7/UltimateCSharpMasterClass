using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateNumberEtc
{
    public static class StackExtensions
    {

        public static bool DoesContainAny(this Stack<string> mystack, params string[] input)
        {
            //bool result = false;
            while(mystack.Count > 0)
            {
                var nextstring = mystack.Pop();

                // return ContainsString(nextstring, input);

                if (input.Where(
                    item =>
                    item == nextstring).Any()
                    )
                {
                    return true;
                }
            }
            return false;
        }

    public static bool ContainsString(string str, string[] array)
    {
            return array.Where(item => item == str).Any();
    }
        
             

  }

}
