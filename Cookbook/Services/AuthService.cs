using System;
using System.Threading.Tasks;
using Cookbook.Api.Auth;
using Cookbook.Models.Domain.Client;
using Cookbook.Settings;

namespace Cookbook.Services;

public class AuthService
{
    private readonly AuthApi _authApi = new AuthApi();
    private AppSettings _appSettings = App.Settings!;

    public async Task GuestAsync()
    {
        try
        {
            var token = await _authApi.GuestAsync();

            if (token == null)
                throw new Exception("Непредвиденная ошибка");
            
            _appSettings.Token = token;
            
            SettingsManager.SaveSettings(_appSettings);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task LoginAsync(string login, string password)
    {
        try
        {
            var token = await _authApi.LoginAsync(login, password);

            if (token == null)
                throw new Exception("Непредвиденная ошибка");
            
            _appSettings.Token = token;
            
            SettingsManager.SaveSettings(_appSettings);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}