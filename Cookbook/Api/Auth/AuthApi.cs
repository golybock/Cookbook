using System;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blank.Client;

namespace Cookbook.Api.Auth;

public class AuthApi : ApiBase
{
    private readonly string Login = "Login";

    private readonly string Registration = "Registration";

    private readonly string UpdatePasswsord = "UpdatePasswsord";

    private readonly string Guest = "Guest";

    public async Task<string?> LoginAsync(string login, string password)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Auth}/{Login}";
        
        client.DefaultRequestHeaders.Add("login", login);
        client.DefaultRequestHeaders.Add("password", password);

        var res = await client.PostAsync(new Uri(url), null);

        if (res.IsSuccessStatusCode)
            return await res.Content.ReadAsStringAsync();

        return null;
    }
    
    public async Task<string?> RegistrationAsync(ClientBlank clientBlank)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Auth}/{Registration}";
        
        var res = await client.PostAsJsonAsync(new Uri(url), clientBlank);

        if (res.IsSuccessStatusCode)
            return await res.Content.ReadAsStringAsync();

        return null;
    }
    
    public async Task<bool?> UpdatePasswordAsync(string password, string newPassword)
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Auth}/{UpdatePasswsord}?password={password}&newPassword={newPassword}";

        client.DefaultRequestHeaders.Add("token", Token);
        
        var res = await client.PostAsync(new Uri(url), null);

        if (res.StatusCode == HttpStatusCode.Unauthorized)
            throw new Exception("Сессия недействительна");
        
        return res.IsSuccessStatusCode;
    }
    
    public async Task<string?> GuestAsync()
    {
        var client = GetHttpClient();

        string url = $"{BaseUrl}/{Auth}/{Guest}";

        var res = await client.PostAsync(new Uri(url), null);

        if (res.IsSuccessStatusCode)
            return await res.Content.ReadAsStringAsync();

        return null;
    }
}