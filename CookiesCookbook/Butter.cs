using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    class Butter : Ingredient, IStirable
    {
        public Condition Condition { get; set; }
        public Butter(int id, string name, int iamount, Measurement imeasurement, Condition condition) : base(id, name, iamount, imeasurement)
        {
            Condition = condition; 
            base.BuildDescription(this);
        }

    }
}
