using System;
using System.Collections.Generic;
using System.Text;

namespace CookiesCookbook
{
    class Program
    {
        public static List<Ingredient> Ingredients = new List<Ingredient>();
        static void Main(string[] args)
        {
            Ingredients.Add(new Flour(1, "Wheatflour", 2, Measurement.dl, 125, TimeSpan.FromMinutes(25)));
            Ingredients.Add(new Flour(2, "Barleyflour", 3, Measurement.dl, 125, TimeSpan.FromMinutes(25)));
            Ingredients.Add(new Butter(3, "LightButter", 2, Measurement.msk, Condition.briefly_mixed));
            string choice;
            
            do
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine($"Create a new cookie recipe! Available ingredients are:");
                foreach(Ingredient ingredient in Ingredients) 
                {
                    builder.AppendLine($"{ingredient.ID}.{ingredient.Name}");
                }
                builder.AppendLine("Add an ingredient by it's Id or type anything else if finished");
                
                Console.WriteLine(builder.ToString());
                choice = Console.ReadLine();
                
            } while (string.IsNullOrWhiteSpace(choice) && !Ingredients.Exists((n) => n.ID.ToString() == choice));
        
            
        }
    }
}
