using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache
{
    public class CustomCache<TKey, TData>
    {
        private Dictionary<TKey, TData> _dict = new();

        
        public TData GetData(TKey key, Func<TKey,TData> getDataOnFirstTry) 
        {
            
            if (!_dict.ContainsKey(key))
            {
                //var data = getDataOnFirstTry;
                _dict.Add(key, getDataOnFirstTry(key));  // value = data förutom att returnera värdet körs metoden med olika extensions , implementationer 
               
            }
            return _dict[key];
        }
        

    }
}
