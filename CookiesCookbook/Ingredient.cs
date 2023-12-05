using System;
using System.Text;

namespace CookiesCookbook
{
    public enum Condition
    {
        briefly_mixed,
        homogenuous,
        firm,
    }
   public enum Measurement
    {
        ml,
        dl,
        msk,
    }

        
    interface IHeatable
    {
        public int Temperature { get; set; }
        public TimeSpan Time { get; set; }
        //public string Describe() { return $"is heated for {Time} at {Temperature} degrees"; }

    }

    interface IStirable
    {
        public Condition Condition { get; set; }
        //public string Describe() { return $"is Stired until {condition}"; }
    }

    interface IIngredient
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; set; }
        public int Amount { get; }
        public Measurement Measurement { get; } //enum msk, dl, kryddmått
       
    }
    public abstract class Ingredient
    {
        public int ID { get; }
        public string Name { get; }

        private string Description { get; set; }
        public int Amount { get; }
        public Measurement Measurement{ get;} //enum msk, dl, kryddmått
        
        public Ingredient(int id, string name, int iamount, Measurement imeasurement)
        {
            ID = id; Name = name; Amount = iamount; Measurement = imeasurement;
            
        }
       
        public virtual string BuildDescription(object ingredient) 
        {
            StringBuilder builder = new StringBuilder();
            builder.Append( $"{Amount} {Measurement} of {Name}");
            
            if (ingredient is IStirable stirable)
            {
                builder.Append($"is stired until {stirable.Condition}.");
                
            }
            if (ingredient is IHeatable && ingredient is IStirable) { builder.Append("& "); } 
      
            if (ingredient is IHeatable heatable)
            {
                builder.Append($"is heated at {heatable.Temperature} for {heatable.Time}.");
            }
            
            return builder.ToString();
            
        }

        public string GetDescription() => Description;
    }


}