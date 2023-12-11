using CookiesCookbook.FileAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook.FileAccess
{
    
        public static class FileFormatExtensions
        {

            public static string AsFileExtension(this FileFormat fileFormat) =>
                fileFormat == FileFormat.Json ? "json" : "txt";
        }
    
}
