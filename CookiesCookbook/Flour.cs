using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    class Flour : Ingredient,IIngredient, IHeatable 
    {
        public int Temperature { get; set; }
        public TimeSpan Time { get; set; }
        //public int ID { get; }
        public string Name { get; }
        public string Description { get; set; }
        public int Amount { get; }
        public Measurement Measurement { get;}

        public Flour(int id, string name, int iamount, Measurement imeasurement, int temperature, TimeSpan time):base(id,name,iamount,imeasurement)
        {
            Time = time;
            Temperature = temperature;
            Description = base.BuildDescription(this);
        }
       
    }
}
