using System;
using System.Collections.Generic;
using System.Text;

namespace CookiesCookbook
{
    public class Conditions
    {
        public static string Mixed_lightly { get; } = "mixed lightly";
        public static string Homogenous { get; } = "homogenous";
        public static string Firm { get; } = "firm";

    }
        
    
   public enum Measurement
    {
        ml,
        dl,
        msk,
    }

    interface IIngredient
    {
        public int ID { get; }
        public string Name { get; }
        public string Preparation { get; set; }
        public int Amount { get; }
        public Measurement Measurement { get; } //enum msk, dl, kryddmått
       
    }
    public abstract class Ingredient

    {

        public int ID { get; }
        public string Name { get; }

        public string Preparation { get; init; }
        //public virtual string Preparation => "Add to other ingredients";
        public int Amount { get; }
        public Measurement Measurement{ get;} //enum msk, dl, kryddmått

        #nullable enable
       
        public Ingredient(int id, string name, int iamount, Measurement imeasurement)
        {
            ID = id; Name = name; Amount = iamount; Measurement = imeasurement; 
            Preparation = BuildPreparation(this);
           

        }
       
        public virtual string BuildPreparation(Ingredient ingredient) //varför overrida? när du använder både base och den här i t.ex. Butter klassen ?
        {
            StringBuilder builder = new StringBuilder();
            builder.Append( $"{Amount} {Measurement} of {Name}");
            
            if (ingredient is IStirrable stirable)
            {
                builder.Append($" is stirred until {stirable.Condition}.");
                
            }
            //if (ingredient is IHeatable && ingredient is IStirrable) { builder.Append("& "); } 
      
            if (ingredient is IHeatable heatable)
            {
                builder.Append($" is heated at {heatable.Temperature} degrees for {heatable.Time} amount of time.");
            }
            
            return builder.ToString();
            
        }

        public string GetDescription() => Preparation;
    }


}