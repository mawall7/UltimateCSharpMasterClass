using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UltimateCSharpMasterClass;

namespace ValidateNumberEtc
{
   
    public interface ITypesSuggester
    {
        public static Dictionary<string, MaxMinTypeDescription> types = new Dictionary<string, MaxMinTypeDescription>();
        public string FindSmallestNumericType(BigInteger maxvalue,BigInteger minvalue, bool IsOnlyIntegral, bool isPrecise);
       
    }
        /// <summary> 
        /// <c>FindSmallestNumericType</c> returns a type within range with smallest possible range or for infinity
        /// targetvalue is the types to filter from (set to null filters all numeric types)and value is the targeted value
        /// </summary>
       
    public class NumericsTypeSuggester : ITypesSuggester
    {
        
        public static Dictionary <string, MaxMinTypeDescription> types = new Dictionary<string, MaxMinTypeDescription>()
            {
                {"sbyte", new MaxMinTypeDescription(sbyte.MaxValue, sbyte.MinValue)},
                {"byte", new MaxMinTypeDescription(byte.MaxValue, byte.MinValue)},
                {"short", new MaxMinTypeDescription(short.MaxValue, short.MinValue)},
                {"ushort", new MaxMinTypeDescription(ushort.MaxValue, ushort.MinValue)},
                {"int", new MaxMinTypeDescription(int.MaxValue, int.MinValue)},
                {"uint", new MaxMinTypeDescription(uint.MaxValue, uint.MinValue)},
                {"long", new MaxMinTypeDescription(long.MaxValue, long.MinValue)},
                {"ulong", new MaxMinTypeDescription(ulong.MaxValue, ulong.MinValue)},
                {"decimal", new MaxMinTypeDescription((double)decimal.MaxValue, (double)decimal.MinValue)},
                {"double", new MaxMinTypeDescription(double.MaxValue, double.MinValue)},
                {"float", new MaxMinTypeDescription(float.MaxValue, float.MinValue)},
       
        };


        public string FindSmallestNumericType(BigInteger numbermax, BigInteger numbermin, bool IsOnlyIntegral, bool isPrecise)
        {
            string? result = default;
            //används record istället för dictionary hade det inte behövt att skapas en ny dictionary eftersom den är en valutype instans
            BigInteger valuemin = (BigInteger)numbermax;
            
            Dictionary<string, MaxMinTypeDescription> targettypes = new();
            List<KeyValuePair<string, MaxMinTypeDescription>>? preliminaryresult = targettypes.ToList();
            List<KeyValuePair<string, MaxMinTypeDescription>>? resultat = default;

            foreach (var item in types)
            {
                targettypes[item.Key] = item.Value;
            }

            if (IsOnlyIntegral)
            {
               
                resultat = targettypes?.Where(type => type.Key != "decimal" && type.Key != "double" && type.Key != "float").ToList();
                resultat.Add(new KeyValuePair<string, MaxMinTypeDescription>("Big Integer", new MaxMinTypeDescription(double.Parse("999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999"), double.Parse("999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999"))));
            } 
            else if(!IsOnlyIntegral)
            {
                resultat = targettypes.Where(type => type.Key == "decimal" || type.Key == "double" || type.Key == "float").ToList();
            }
           
            resultat = resultat.Where(dict => (BigInteger)dict.Value.Max >= numbermax && (BigInteger)dict.Value.Min <= numbermin).ToList();

            if (resultat.ToList().Count > 1)
            {
                resultat = resultat.OrderBy(type => type.Value.Max).ToList();
            }

            if (resultat.ToList().Count > 1)
            {
                result = double.IsInfinity((double)numbermax) || double.IsInfinity((double)numbermin) ? typeof(BigInteger).Name : resultat.ToList().First().Key;
            }

            if (isPrecise)// !isOnly Integral
            {
                
                var prelresultat = resultat.Where(item => item.Key == "decimal").ToList();
                if (prelresultat == null) 
                {
                    return "impossible representation";
                }
                resultat = prelresultat;
            }
            else if (!isPrecise)
            {
                if(resultat.Count == 0)
                {
                    return "Big Integer";
                }
                resultat = resultat.Where(item => item.Key != "decimal").ToList();
                
            }
                 
            result = resultat.ToList().Count() == 0 ? "impossible representation" : resultat.First().Key;
            return result;
        }


            
            
            

            


    }
}
    

