using System;
using System.Collections.Generic;

namespace CookiesCookbook
{
    class Program
    {
        public static List<Ingredient> Ingredients = new List<Ingredient>();
        static void Main(string[] args)
        {
            string choice;

            
            do
            {
                Console.WriteLine($"Create a new cookie recipe! Available ingredients are:\n{Ingredients.ForEach(i => i)}\nAdd an ingredient by it's Id or type anything else if finished");
                choice = Console.ReadLine();
                
            } while (string.IsNullOrWhiteSpace(choice));
        
            
        }
    }
}
