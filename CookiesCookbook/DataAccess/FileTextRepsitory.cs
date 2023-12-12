using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.DataAccess
{
    public class FileTextRepsitory: FileRepository
    {

        private static readonly string Separator = Environment.NewLine;
        protected override string StringsToText(List<string> strings)
        {
            return string.Join(Separator, strings);
        }
            

        protected override List<string> TextToStrings(string fileContents)
        {
            return fileContents.Split(Separator).ToList();
        }
    }
}
