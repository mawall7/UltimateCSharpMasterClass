using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    using CookiesCookbook.DataAccess;
    public class Recipe
    {
       
        public IEnumerable<Ingredient> Cookierecipe { get; }
        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            Cookierecipe = ingredients;
        }

        public void PrintAll()
        {
            foreach (Ingredient item in Cookierecipe)
            {
                Console.WriteLine(item.Preparation);//Console.WriteLine(item?.Preparation);


            }
        }
        public override string ToString()
        {
            var steps = new List<string>();
            foreach (var ingredient in Cookierecipe)
            {
                steps.Add($"{ingredient.Preparation}");
            }

            return string.Join(Environment.NewLine, steps); //flour.is sieved\butter.is heated. 
        }
    }

}

