using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blank.Client;
using Domain.Client;
using Domain.Recipe;

namespace Cookbook.Api.Client;

public class ClientApi : ApiBase
{
    // method names
    private readonly string _client = "Client";
    
    private readonly string _clientImage = "ClientImage";

    private readonly string _likedRecipes = "LikedRecipes";

    private readonly string _like = "Like";

    private readonly string _unLike = "UnLike";
    
    // method calls
    
    // client
    public async Task<ClientDomain?> GetClientAsync()
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Client}/{_client}";
        
        client.DefaultRequestHeaders.Add("token", Token);

        var res = await client.GetAsync(url);

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");
        
        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ClientDomain>(content);
        }

        return null;
    }
    
    public async Task<bool> UpdateClientAsync(ClientBlank clientBlank)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Client}/{_client}";
        
        client.DefaultRequestHeaders.Add("token", Token);

        var res = await client.PostAsJsonAsync(new Uri(url), clientBlank);

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");
        
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> DeleteClientAsync()
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Client}/{_client}";
        
        client.DefaultRequestHeaders.Add("token", Token);

        var res = await client.DeleteAsync(new Uri(url));

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");
        
        return res.IsSuccessStatusCode;
    }
    
    // clientImage
    
    public async Task<string?> GetClientImageAsync()
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Client}/{_clientImage}";
        
        client.DefaultRequestHeaders.Add("token", Token);

        var res = await client.GetAsync(url);

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");
        
        if (res.IsSuccessStatusCode)
            return await res.Content.ReadAsStringAsync();

        return null;
    }
    
    public async Task<string?> UploadClientImageAsync(string path)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Client}/{_clientImage}";
        
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
    
    public async Task<bool> DeleteClientImageAsync()
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Client}/{_clientImage}";
        
        client.DefaultRequestHeaders.Add("token", Token);
        
        var res = await client.DeleteAsync(url);

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");
        
        return res.IsSuccessStatusCode;
    }
    
    // liked recipes
    
    public async Task<List<RecipeDomain>?> GetLikedRecipesAsync()
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Client}/{_likedRecipes}";
        
        client.DefaultRequestHeaders.Add("token", Token);

        var res = await client.GetAsync(url);

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");

        if (res.IsSuccessStatusCode)
        {
            var content = await res.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<RecipeDomain>>(content);
        }

        return null;
    }
    
    public async Task<bool> LikeRecipeAsync(string code)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Client}/{_like}?recipeCode={code}";
        
        client.DefaultRequestHeaders.Add("token", Token);
        
        var res = await client.PostAsync(new Uri(url), null);

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");
        
        return res.IsSuccessStatusCode;
    }
    
    public async Task<bool> UnLikeRecipeAsync(string code)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Client}/{_unLike}?recipeCode={code}";
        
        client.DefaultRequestHeaders.Add("token", Token);
        
        var res = await client.PostAsync(new Uri(url), null);

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");
        
        return res.IsSuccessStatusCode;
    }
}