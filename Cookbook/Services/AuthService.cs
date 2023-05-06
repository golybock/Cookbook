using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cookbook.Api.Auth;
using Cookbook.Models.Blank.Client;
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
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
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
                throw new Exception("Неверный логин или пароль");
            
            _appSettings.Token = token;
            
            SettingsManager.SaveSettings(_appSettings);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task RegistrationAsync(ClientBlank clientBlank)
    {
        try
        {
            var token = await _authApi.RegistrationAsync(clientBlank);

            if (token == null)
                throw new Exception("Возникла непредвиденная ошибка");
            
            _appSettings.Token = token;
            
            SettingsManager.SaveSettings(_appSettings);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task UpdatePasswordAsync(string password, string newPassword)
    {
        try
        {
            var res = await _authApi.UpdatePasswordAsync(password, newPassword);

            if (res is true)
                SettingsManager.SaveSettings(_appSettings);

            else
                throw new Exception("Возникла непредвиденная ошибка");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task UnLogin()
    {
        _appSettings.Token = null;
            
        SettingsManager.SaveSettings(_appSettings);
    }
}