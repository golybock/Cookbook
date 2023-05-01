using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Cookbook.Models.Blank.Recipe.Category;
using Cookbook.Models.Blank.Recipe.Ingredient;
using Cookbook.Models.Domain.Recipe.Category;
using Cookbook.Models.Domain.Recipe.Ingredient;

namespace Cookbook.Api.Recipe.Ingredient;

public class IngredientApi : ApiBase
{
    // method names
    private readonly string _ingredient = "Ingredient";
    private readonly string _ingredients = "Ingredients";
    
    // method calls
    public async Task<IngredientDomain?> GetIngredientAsync(int id)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Ingredient}/{_ingredient}?id={id}";

        var res = await client.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IngredientDomain>(content);
        }

        return null;
    }
    
    public async Task<List<IngredientDomain>?> GetIngredientsAsync()
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Ingredient}/{_ingredients}";

        var res = await client.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<IngredientDomain>>(content);
        }

        return null;
    }

    public async Task<int?> PostIngredientAsync(IngredientBlank ingredientBlank)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Ingredient}/{_ingredient}";

        var res = await client.PostAsJsonAsync(new Uri(url), ingredientBlank);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return Int32.Parse(content);
        }

        return null;
    }
    
    public async Task<bool> DeleteIngredientAsync(int id)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Ingredient}/{_ingredient}?id={id}";

        var res = await client.DeleteAsync(new Uri(url));
        
        return res.IsSuccessStatusCode;
    }
}