using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    interface IHeatable
    {
        public int Temperature { get; set; }
        public TimeSpan Time { get; set; }
    }
}
