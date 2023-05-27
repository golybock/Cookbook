using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Database;
using Cookbook.Settings;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Services;

public class ClientService : IClientService
{
    public Client GetCurrent()
    {
        string email = App.Settings.Email;
        
        return App.Context.Clients.FirstOrDefault(c => c.Email == email);
    }

    public async Task<Client> Login(string login, string password)
    {
        var client = await App.Context.Clients.FirstOrDefaultAsync(c => c.Email == login);

        if (client == null)
            throw new Exception("Пользователь не найден");
        
        if (client.Password != password)
            throw new Exception("Неверный пароль");
        
        var settings = App.Settings;
        settings.Email = login;
        settings.Password = password;
        SettingsManager.SaveSettings(settings);

        return client;
    }

    public async Task<Client> Update(Client client, string? image)
    {
        var cl = await App.Context.Clients.FirstOrDefaultAsync(c => c.Email == client.Email);
        
        if(image != null)
            client.ImagePath = await CopyImageToBin(image);

        App.Context.Clients.Update(client);
        await App.Context.SaveChangesAsync();

        return client;
    }

    public async Task<Client> Registration(Client client, string? image)
    {
        var cl = await App.Context.Clients.FirstOrDefaultAsync(c => c.Email == client.Email);

        if (cl != null)
            throw new Exception("Пользователь уже зарегистрирован");

        if (!ValidateEmail(client.Email))
            throw new Exception("Неверный формат почты");
        
        if (!ValidatePassword(client.Password))
            throw new Exception("Неверный формат пароля");

        if(image != null)
            client.ImagePath = await CopyImageToBin(image);

        await App.Context.Clients.AddAsync(client);
        await App.Context.SaveChangesAsync();
        
        var settings = App.Settings;
        settings.Email = client.Email;
        settings.Password = client.Password;
        SettingsManager.SaveSettings(settings);

        return client;
    }

    public void UnLogin()
    {
        var settings = App.Settings;
        settings.Email = null;
        settings.Password = null;
        SettingsManager.SaveSettings(settings);
    }
    
    #region validation

    private async Task<string> CopyImageToBin(string image)
    {
        string path = Guid.NewGuid() + ".png";
        
        File.Copy(image, path);

        return path;
    }
    
    // validate password 
    private bool ValidatePassword(string password) =>
        password.Any(char.IsLetter) &&
        password.Any(char.IsDigit) &&
        password.Any(char.IsUpper) &&
        password.Any(char.IsLower) &&
        password.Length >= 8;

    // validate email
    private bool ValidateEmail(string email) =>
        new EmailAddressAttribute().IsValid(email);

    #endregion
}