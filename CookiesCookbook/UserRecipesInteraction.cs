using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookiesCookbook
{
    class UserRecipesInteraction : IRecipesUserInteraction
    {
        private readonly IIngredientsRegister _ingredientsRegister;
        
        public UserRecipesInteraction(IIngredientsRegister ingredientsRegister)
        {
            _ingredientsRegister = ingredientsRegister;
        }
        public void Exit()
        {
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
           
        }

        public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
        {
            

            if (allRecipes.Any())
            {
                
                Console.WriteLine("Existing recipes are:" + Environment.NewLine);

                var counter = 1;
                foreach (var recipe in allRecipes)
                {
                    Console.WriteLine($"*****{counter}*****");
                    Console.WriteLine(recipe);
                    Console.WriteLine();
                    ++counter;
                }
            }

        }

        public void PromptToCreateRecipe()
        {
            Console.WriteLine("Create a new cookie recipe! " +
                "Available ingredients are:");

            foreach (var ingredient in _ingredientsRegister.Ingredients)
            {
                Console.WriteLine(ingredient.ID + $".{ingredient.Name}.");
            }
        }

        

            public IEnumerable<Ingredient> ReadIngredientsFromUser()
            {
                bool shallStop = false;
                var ingredients = new List<Ingredient>();

                while (!shallStop)
                {
                    Console.WriteLine("Add an ingredient by its ID, " +
                        "or type anything else if finished.");

                    var userInput = Console.ReadLine();

                    if (int.TryParse(userInput, out int id))
                    {
                        var selectedIngredient = _ingredientsRegister.GetById(id);
                        if (selectedIngredient is not null)
                        {
                            ingredients.Add(selectedIngredient);
                        }
                        else shallStop = true;
                    }
                    else
                    {
                        shallStop = true;
                    }
                }

                return ingredients;
            }
        

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
