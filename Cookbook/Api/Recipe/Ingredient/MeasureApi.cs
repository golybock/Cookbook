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

public class MeasureApi : ApiBase
{
    private readonly string Measure = "Measure";
    
    private readonly string Measures = "Measures";
    
    public async Task<MeasureDomain?> GetCategoryAsync(int id)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Measure}?id={id}";

        var res = await client.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<MeasureDomain>(content);
        }

        return null;
    }
    
    public async Task<List<MeasureDomain>?> GetCategoriesAsync()
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Measure}";

        var res = await client.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<MeasureDomain>>(content);
        }

        return null;
    }

    public async Task<int?> PostMeasureAsync(MeasureBlank measureBlank)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Measure}/{Measure}";

        var res = await client.PostAsJsonAsync(new Uri(url), measureBlank);

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

        string url = $"{BaseUrl}/{Category}?id={id}";

        var res = await client.DeleteAsync(new Uri(url));
        
        return res.IsSuccessStatusCode;
    }
}