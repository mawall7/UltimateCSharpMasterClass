using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CookieCookbook.FileAccess;
using CookiesCookbook.DataAccess;
using CookiesCookbook.FileAccess;

namespace CookiesCookbook
{
    class Program
    {
        public static List<Ingredient> Ingredients = new ();
        //public static Recipe NewRecipe { get; set; }
        // public static List<Ingredient> Recipe = new List<Ingredient>();
        private readonly IFileRepository _fileRepository;
        private readonly IngredientsRegister _ingredientsRegister;
        const FileFormat File_Format = FileFormat.Json;
   
        public static void Main(string[] args)
        {
            FileRepository fileRepository = File_Format == FileFormat.Json ?
                new JsonFileRepository() : new FileTextRepsitory();

            const string fileName = "recipes";

            var fileMetaData = new FileMetaData(fileName, File_Format);
            var IngredientsRegister = new IngredientsRegister();

            CookiesRecipesApp CookiesRecipesApp = new CookiesRecipesApp(
            new UserRecipesInteraction(
                IngredientsRegister),
            new RecipeRepository(
                fileRepository,
                IngredientsRegister));

            CookiesRecipesApp.Run(fileMetaData.ToPath());
        }

    }
 }




