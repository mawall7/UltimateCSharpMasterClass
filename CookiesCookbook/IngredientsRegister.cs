using System;
using System.Collections.Generic;
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
            new Butter(3, "LightButter", 2, Measurement.msk, Conditions.Mixed_lightly.ToString(), 100, TimeSpan.FromMinutes(30))
        };
      
        public void Add(Ingredient ingredient)
        {
            if(ingredient != null)
            Ingredients.Append(ingredient);
        }

        public Ingredient GetById(int id) => Ingredients.Where(i => i.ID == id).FirstOrDefault();
        
    }
           
        
}
