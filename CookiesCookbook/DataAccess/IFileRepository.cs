using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.DataAccess
{
        public interface IFileRepository
        {
        public List<string> Read(string path = "recepies.txt");
        public void Save(List<string> data, string path);


        }
    
}
