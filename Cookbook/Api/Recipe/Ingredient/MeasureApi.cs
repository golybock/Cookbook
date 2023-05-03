using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Blank.Recipe.Ingredient;
using Domain.Recipe.Ingredient;

namespace Cookbook.Api.Recipe.Ingredient;

public class MeasureApi : ApiBase
{
    // method names
    private readonly string _measure = "Measure";
    
    private readonly string _measures = "Measures";
    
    // method calls
    public async Task<MeasureDomain?> GetMeasureAsync(int id)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Measure}/{_measure}?id={id}";

        var res = await client.GetAsync(url);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<MeasureDomain>(content);
        }

        return null;
    }
    
    public async Task<List<MeasureDomain>?> GetMeasuresAsync()
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Measure}/{_measure}";

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

        string url = $"{BaseUrl}/{Measure}/{_measure}";

        var res = await client.PostAsJsonAsync(new Uri(url), measureBlank);

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return Int32.Parse(content);
        }

        return null;
    }
    
    public async Task<bool> DeleteMeasureAsync(int id)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Measure}/{_measure}?id={id}";

        var res = await client.DeleteAsync(new Uri(url));
        
        return res.IsSuccessStatusCode;
    }
}