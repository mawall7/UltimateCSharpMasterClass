using CookiesCookbook.Recipes.Ingredients;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    class IngredientsRegister : IIngredientsRegister
    {
        
        public IEnumerable<Ingredient> Ingredients { get; } = new List<Ingredient>
        {
            new Flour(1, "Wheatflour", 2, Measurement.dl, 125, TimeSpan.FromMinutes(25)),
            new Flour(2, "Barleyflour", 3, Measurement.dl, 125, TimeSpan.FromMinutes(25)),
            new Butter(3, "LightButter", 2, Measurement.msk, Conditions.Mixed_lightly.ToString(), 100, TimeSpan.FromMinutes(30)),
            new Cinnamon(4, "Cinnamon", 1, Measurement.msk)
        };
      
        public void Add(Ingredient ingredient)
        {
            if(ingredient != null)
            Ingredients.Append(ingredient);
        }

        public Ingredient GetById(int id)
        {
            var ingredientsWithGivenId = Ingredients
                .Where(ingredient => ingredient.ID == id);

            if(ingredientsWithGivenId.Count() > 1)
            {
                throw new InvalidOperationException(
                    $"More than one ingredient have ID equal to {id}");
            }
            //if(Ingredients.Select(ingredient => ingredient.ID).Distinct().Count() != Ingredients.Count())
            //{
            //    throw new InvalidOperationException(
            //        $"Some ingredients have duplicated iDs.");
            //}

           
            return Ingredients.FirstOrDefault();
        }
        
    }
           
        
}
