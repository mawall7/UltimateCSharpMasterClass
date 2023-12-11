using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
     public interface IRecipesUserInteraction
        {
            void ShowMessage(string message);
            void Exit();
            void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
            void PromptToCreateRecipe();
            IEnumerable<Ingredient> ReadIngredientsFromUser();
        }
    }

