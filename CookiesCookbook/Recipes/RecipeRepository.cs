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
            //List<string> recipesFromFile = _filerepository.Read(filePath);
            return  _filerepository.Read(filePath)
            .Select(RecipeFromString)
            .ToList();
            //var recipes = new List<Recipe>();

            //if (recipesFromFile is not null)
            //{

            //    foreach (var recipeFromFile in recipesFromFile)
            //    {
            //        var recipe = RecipeFromString(recipeFromFile);
            //        recipes.Add(recipe);
            //    }
            //}

            //return recipes;
        }

        private Recipe RecipeFromString(string recipeFromFile)
        {
            var textualIds = recipeFromFile.Split(Separator); //t.ex: ["1","3","2"] av "1,2,3";
            var ingredients = textualIds
                .Select(textualId => int.Parse(textualId)) //genom LINQ select får man en IEnumerable
                .Select(id => _ingredientsRegister.GetById(id));
                
            return new Recipe(ingredients);
            //var mystring = "1,2,3"; mystring.Split(",");
            //mystring.Select(item => { int i = 0; i++; return $"{i} {item}"; });
        }


        public void Write(List<Recipe> recipes, string filePath)
        {
            var ingredientscollection = recipes
                .Select(recipe =>
                {
                    var allids = recipe.Cookierecipe
                    .Select(ingredient => ingredient.ID);
                    return string.Join(Separator, allids);
                }).ToList();
            _filerepository.Save(ingredientscollection, filePath);
                
           
            //var recipesasstring = string.Join(",", ingredientscollection);



            //List<string> recipesAsString = new List<string>();

            //foreach(Recipe recipe in recipes)
            //{
            //    var ridlist = new List<int>();

            //    foreach(Ingredient ingredient in recipe.Cookierecipe)
            //    {
            //        ridlist.Add(ingredient.ID);

            //    }
            //       recipesAsString.Add(string.Join(Separator, ridlist));// [1,2],[2,4,5]...
            //}

            //_filerepository.Save(recipesAsString, filePath);
        }

    }
}
