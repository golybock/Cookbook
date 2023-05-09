using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Cookbook.Models.Blank.Recipe;
using Cookbook.Models.Domain.Recipe;
using Cookbook.Models.Domain.Recipe.Ingredient;

namespace Cookbook.Api.Recipe;

public class RecipeApi : ApiBase
{
    // method names
    private readonly string _recipe = "Recipe";
    private readonly string _recipes = "Recipes";
    private readonly string _likedRecipes = "LikedRecipes";
    private readonly string _clientRecipes = "ClientRecipes";
    private readonly string _recipeImage = "RecipeImage";
    
    // method calls
    public async Task<RecipeDomain?> GetRecipeAsync(string code)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Recipe}/{_recipe}?recipeCode={code}";

        var res = await client.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<RecipeDomain>(content);
        }

        return null;
    }
    
    public async Task<string?> PostRecipeAsync(RecipeBlank recipeBlank)
    {
        var client = GetHttpClient();

        client.DefaultRequestHeaders.Add("token", Token);
        
        string url = $"{BaseUrl}/{Recipe}/{_recipe}";

        var res = await client.PostAsJsonAsync(new Uri(url), recipeBlank);

        if (res.IsSuccessStatusCode)
            return await res.Content.ReadAsStringAsync();

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");

        if (res.StatusCode == HttpStatusCode.BadRequest)
            throw new Exception(await res.Content.ReadAsStringAsync());
        
        return null;
    }
    
    public async Task<string?> UpdateRecipeAsync(RecipeBlank recipeBlank, string code)
    {
        var client = GetHttpClient();

        client.DefaultRequestHeaders.Add("token", Token);
        
        string url = $"{BaseUrl}/{Recipe}/{_recipe}?recipeCode={code}";

        var res = await client.PutAsJsonAsync(new Uri(url), recipeBlank);

        if (res.IsSuccessStatusCode)
            return await res.Content.ReadAsStringAsync();

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");

        if (res.StatusCode == HttpStatusCode.BadRequest)
            throw new Exception(await res.Content.ReadAsStringAsync());
        
        return null;
    }
    
    public async Task<bool?> DeleteRecipeAsync(string Code)
    {
        var client = GetHttpClient();

        client.DefaultRequestHeaders.Add("token", Token);
        
        string url = $"{BaseUrl}/{Recipe}/{_recipe}?recipeCode={Code}";

        var res = await client.DeleteAsync(new Uri(url));
        
        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");

        if (res.StatusCode == HttpStatusCode.BadRequest)
            throw new Exception(await res.Content.ReadAsStringAsync());

        return res.IsSuccessStatusCode;
    }
    
    public async Task<List<RecipeDomain>?> GetRecipesAsync()
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Recipe}/{_recipes}";

        var res = await client.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<RecipeDomain>>(content);
        }

        return null;
    }
    
    public async Task<List<RecipeDomain>?> GetLikedRecipesAsync()
    {
        var client = GetHttpClient();
        
        client.DefaultRequestHeaders.Add("token", Token);

        string url = $"{BaseUrl}/{Recipe}/{_likedRecipes}";

        var res = await client.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<RecipeDomain>>(content);
        }

        return null;
    }
    
    public async Task<List<RecipeDomain>?> GetClientRecipesAsync()
    {
        var client = GetHttpClient();
        
        client.DefaultRequestHeaders.Add("token", Token);

        string url = $"{BaseUrl}/{Recipe}/{_clientRecipes}";

        var res = await client.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<RecipeDomain>>(content);
        }

        return null;
    }
    
    public async Task<string?> UploadRecipeImageAsync(string path, string code)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Recipe}/{_recipeImage}?code={code}";
        
        client.DefaultRequestHeaders.Add("token", Token);

        var content = new MultipartFormDataContent();

        using (StreamReader sr = new StreamReader(path))
        {
            content.Add(new StreamContent(sr.BaseStream), "image", "image.png");
        }

        var res = await client.PostAsync(new Uri(url), content);

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");
        
        if (res.IsSuccessStatusCode)
            return await res.Content.ReadAsStringAsync();

        return null;
    }
    
    public async Task<bool> DeleteRecipeImageAsync(string code)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Recipe}/{_recipeImage}?recipeCode={code}";
        
        client.DefaultRequestHeaders.Add("token", Token);
        
        var res = await client.DeleteAsync(url);

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");
        
        return res.IsSuccessStatusCode;
    }
}