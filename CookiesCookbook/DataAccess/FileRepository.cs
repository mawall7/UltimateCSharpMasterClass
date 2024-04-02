using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.DataAccess
{
    public abstract class FileRepository : IFileRepository
    {
        public virtual List<string> Read(string path = "recepies.txt")
        {
            if (File.Exists(path))
            {
                var data = File.ReadAllText(path);
                var datatoread = File.OpenRead(path);
                
                return TextToStrings(data);
            }
            return null;
        }
        protected abstract string StringsToText(List<string> data);
        
        public void Save(List<string> data, string path)
        {
            var strdata = StringsToText(data);
        
            File.WriteAllText(path,strdata);
        }
        protected abstract List<string> TextToStrings(string data);

        
        

    }
}
