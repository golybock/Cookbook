using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Cookbook.Models.Domain.Recipe;
using Cookbook.Models.Domain.Recipe.Ingredient;

namespace Cookbook.Api.Recipe;

public class RecipeTypeApi : ApiBase
{
    // method names
    private readonly string _recipeTypes = "RecipeTypes";
    
    // method calls
    public async Task<List<RecipeTypeDomain>?> GetRecipeTypesAsync()
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Measure}/{_recipeTypes}";

        var res = await client.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<RecipeTypeDomain>>(content);
        }

        return null;
    }
}