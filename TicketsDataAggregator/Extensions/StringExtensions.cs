using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsDataAggregator.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveSubstring( this string source, string target)
        {

            int index = source.IndexOf(target);
            string cleanString = (index < 0)
                ? source
                : source.Remove(index, target.Length);

            return cleanString;
        }

       
        public static string ReturnsSubstringFromIndex(this string source , int startIndex, int endIndex)
        {
            int length = endIndex;
            return source.Substring(startIndex, length);
        }

        public static string ReturnCultureFormat(this string domainSuffix)
        {
            Dictionary<string, string> cultureInfoDictionary = new Dictionary<string, string>()
            {
                //{".com", "en-US"},
                //{".fr","fr-FR"},
                //{".jp","jp-JP"}
                {".com", "mm-dd-yyyy"},
                {".fr","dd/MM/yyyy"},
                {".jp","yyyy/MM/dd"}

            };

            return cultureInfoDictionary[domainSuffix];
        }

        //public static DateTime ConvertToDateTime(this string target)
        //{

        //}

       

      
    }
}
