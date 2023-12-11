using CookiesCookbook.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly IFileRepository _filerepository;
        private readonly IIngredientsRegister _ingredientsRegister;
        private const string Separator = ",";
        public RecipeRepository(IFileRepository repository, IIngredientsRegister ingredientsRegister)
        {
            _filerepository = repository;
            _ingredientsRegister = ingredientsRegister;
        }

        public List<Recipe> Read(string filePath)
        {
            List<string> recipesFromFile = _filerepository.Read(filePath);
            var recipes = new List<Recipe>();

            if (recipesFromFile is not null)
            {

                foreach (var recipeFromFile in recipesFromFile)
                {
                    var recipe = RecipeFromString(recipeFromFile);
                    recipes.Add(recipe);
                }
            }

            return recipes;
        }

        private Recipe RecipeFromString(string recipeFromFile)
        {
            var textualIds = recipeFromFile.Split(Separator);
            var ingredients = new List<Ingredient>();

            foreach (var textualId in textualIds)
            {
                var id = int.Parse(textualId);
                var ingredient = _ingredientsRegister.GetById(id);
                ingredients.Add(ingredient);
            }

            return new Recipe(ingredients);
        }
        public void Write(List<Recipe> recipes, string filePath)
        {
            List<string> recipesAsString = new List<string>();
           
            foreach(Recipe recipe in recipes)
            {
                var ridlist = new List<int>();
                
                foreach(Ingredient ingredient in recipe.Cookierecipe)
                {
                    ridlist.Add(ingredient.ID);

                }
                   recipesAsString.Add(string.Join(Separator, ridlist));// [1,2],[2,4,5]...
            }

            _filerepository.Save(recipesAsString, filePath);
        }

    }
}
