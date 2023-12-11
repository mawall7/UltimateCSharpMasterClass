using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public interface IIngredientsRegister
    {
      IEnumerable<Ingredient> Ingredients { get; }
      void Add(Ingredient ingredient);
      Ingredient GetById(int id); 
        
      
      
    }
        
}
