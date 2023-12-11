using CookiesCookbook.FileAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCookbook.FileAccess
{

    public class FileMetaData
    {
        public string Name { get; }
        public FileFormat Format { get; }

        public FileMetaData(string name, FileFormat format)
        {
            Name = name;
            Format = format;
        }

        public string ToPath() => $"{Name}.{Format.AsFileExtension()}";
    }

}