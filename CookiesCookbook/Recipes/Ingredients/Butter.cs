using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    class Butter : Ingredient, IStirrable, IHeatable
    {
        //public string Condition { get; set; }
        public int Temperature { get; set; }
        public TimeSpan Time { get; set; }
        public string Condition { get; set; }

        public Butter(int id, string name, int iamount, Measurement imeasurement, string condition, int temperature, TimeSpan time) : base(id, name, iamount, imeasurement)
        {
           
            Temperature = temperature;
            Condition = condition;
            base.Preparation = BuildPreparation(this) + base.BuildPreparation(this);


        }
        public override string BuildPreparation(Ingredient ingredient)
        {
            return "Melt."; 
        }


    }
}
