using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Cookbook.Models.Blank.Recipe.Category;
using Cookbook.Models.Domain.Recipe.Category;

namespace Cookbook.Api.Recipe.Category;

public class CategoryApi : ApiBase
{
    // method names
    private readonly string _category = "Category";
    
    private readonly string _categories = "Categories";

    // method calls
    public async Task<CategoryDomain?> GetCategoryAsync(int id)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Category}/{_category}?id={id}";

        var res = await client.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<CategoryDomain>(content);
        }

        return null;
    }
    
    public async Task<List<CategoryDomain>?> GetCategoriesAsync()
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Category}/{_categories}";

        var res = await client.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<CategoryDomain>>(content);
        }

        return null;
    }

    public async Task<int?> PostCategoryAsync(CategoryBlank categoryBlank)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Category}/{_category}";

        var res = await client.PostAsJsonAsync(new Uri(url), categoryBlank);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return Int32.Parse(content);
        }

        return null;
    }
    
    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Category}/{_category}?id={id}";

        var res = await client.DeleteAsync(new Uri(url));
        
        return res.IsSuccessStatusCode;
    }
}