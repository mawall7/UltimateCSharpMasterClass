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

        
        public TData TryCacheData(TKey key, Func<TKey,TData> getDataOnFirstTry) //I Exemplet användes en Func istället som parameter för att hämta data Func<T1,T2> getForTheFirstTime
        {
            
            if (!_dict.ContainsKey(key))
            {
                var data = getDataOnFirstTry;
                _dict.Add(key, getDataOnFirstTry(key));  
               
            }
            return _dict[key];
        }
        

    }
}
