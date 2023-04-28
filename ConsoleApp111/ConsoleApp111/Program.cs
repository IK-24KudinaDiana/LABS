
using ConsoleApp111.Clients;
using ConsoleApp111.Models;
using Newtonsoft.Json;
//коментарі /різні спроби запустити програму
//RecipesClients recipesClients = new RecipesClients();

//var result = recipesClients.GetRecipeAsync("italian wedding soup");

////Console.WriteLine(result.Result);
//Console.WriteLine(result.Result.Recipe[0].Title);

//RecipesClients recipesClients = new RecipesClients();

//var result = await recipesClients.GetRecipesAsync("italian wedding soup");

//Console.WriteLine(result.Recipe[0].Title);
RecipesClients recipesClients = new RecipesClients();
var result = await recipesClients.GetRecipeAsync("italian wedding soup");

Recipes recipes = JsonConvert.DeserializeObject<Recipes>(result);
foreach (Recipe recipe in recipes.Recipe)
{
    Console.WriteLine(recipe.Title);
    Console.WriteLine(recipe.Ingredients);
    Console.WriteLine(recipe.Servings);
    Console.WriteLine(recipe.Instructions);
}
