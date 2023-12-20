using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCache
{
    public class GenericCustomCache
    {
        private Dictionary<object, object> _dict;

        public GenericCustomCache()
        {
            _dict = new Dictionary<object, object>();
        }
       

        public T2 TryCacheData<T1, T2>(T1 key, T2 data) //I Exemplet användes en Func istället som parameter för att hämta data Func<T1,T2> getForTheFirstTime
        {
            
            if (!_dict.ContainsKey(key))
            {
                _dict.Add(key, data);  
                return default; 
            }
            return (T2)Convert.ChangeType(_dict[key], typeof(T2));
        }
        

    }
}
