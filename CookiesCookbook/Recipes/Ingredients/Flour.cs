using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    class Flour : Ingredient, IHeatable 
    {
        //public override int ID => 2;
        public int Temperature { get; set; }
        public TimeSpan Time { get; set; }

        //public override string Preparations => $"Sieved{base.Preparation}" enklare sätt än att använda BuildPreparation som är en variant; 
        //Istället för konstruktor kan properties initialiseras istället / alternativt flour är en abstrakt klass , där det görs i t.ex. WheatFlour klassen istället;
        public Flour(int id, string name, int iamount, Measurement imeasurement, int temperature, TimeSpan time):base(id,name,iamount,imeasurement)
        {
            Time = time;
            Temperature = temperature;
            base.Preparation = BuildPreparation(this) + base.BuildPreparation(this);
        }

        public override string BuildPreparation(Ingredient ingredient)
        {
            return "Sieve";
        }
        

    }
}
