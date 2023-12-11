using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public class CookiesRecipesApp
    {
        private readonly IRecipesUserInteraction _ui;
        private readonly IRecipeRepository _recipeRepository;
        public CookiesRecipesApp(IRecipesUserInteraction recepeui, IRecipeRepository recipeRepository)
        {
            _ui = recepeui;
            _recipeRepository = recipeRepository;
        }
        public void Run(string filePath)
        {
            var allRecepies = _recipeRepository.Read(filePath);
            
            _ui.PrintExistingRecipes(allRecepies);
            _ui.PromptToCreateRecipe();
            var ingredients = _ui.ReadIngredientsFromUser();
            if(ingredients.Count() > 0)
            {
                var recipe = new Recipe(ingredients);
                allRecepies.Add(recipe);
                _recipeRepository.Write(allRecepies, filePath);

                _ui.ShowMessage("Reciep added:");
                _ui.ShowMessage(recipe.ToString());

            }
            else
            {
                _ui.ShowMessage(
               "No ingredients have been selected. " +
               "Recipe will not be saved.");
            }

            _ui.Exit();

        }
    }
}
