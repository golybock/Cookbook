using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;
using CookbookApi.Models.Blank.Client;
using CookbookApi.Repositories.Client;
using CookbookApi.Services.Interfaces.AuthInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Auth;

public class AuthService : IAuthService
{
    private readonly ClientRepository _clientRepository;

    public AuthService()
    {
        _clientRepository = new ClientRepository();
    }
    
    public async Task<IActionResult> Login(string login, string password)
    {
        var client = await _clientRepository.GetClientByLoginAsync(login);

        if (client == null)
            return new UnauthorizedResult();

        if (client.Password == Md5Password(password))
        {
            string token = GenerateToken();

            var result = await UpdateToken(login, token);

            return result > 0 ? new OkObjectResult(token) : new UnauthorizedResult();
        }

        return new UnauthorizedResult();
    }

    
    public async Task<IActionResult> Registration(ClientBlank client)
    {
        if (!PasswordValid(client.Password))
            return new BadRequestObjectResult("Неверный формат пароля");

        string token = GenerateToken();
        
        var res = await CreateClientAsync(client, token);

        return res > 0 ? new OkObjectResult(token) : new BadRequestResult();
    }

    
    public async Task<IActionResult> UpdatePassword(string token, string password, string newPassword)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        if (Md5Password(password) != client.Password)
            return new BadRequestObjectResult("Неверный пароль");
        
        if (!PasswordValid(newPassword))
            return new BadRequestObjectResult("Неверный формат нового пароля");

        var result =  await _clientRepository.UpdatePasswordAsync(client.Id, newPassword);

        return result > 0 ? new OkResult() : new BadRequestObjectResult("Не удалось обновить пароль");
    }
    
    private async Task<int> UpdateToken(string login, string token)
    {
        var client = await _clientRepository.GetClientByLoginAsync(login);

        if (client == null)
            return 0;

        int id = client.Id;
        
        return await _clientRepository.UpdateTokenAsync(id, token);;
    }
    
    public async Task<IActionResult> Guest()
    {
        var token = GenerateToken();

        var res = await CreateGuestAsync(token);

            return res > 0 ? new OkObjectResult(token) : new BadRequestResult();
    }

    private string Md5Password(string password)
    {
        using var md5 = MD5.Create();
        
        byte[] input = Encoding.UTF8.GetBytes(password);
        byte[] output = md5.ComputeHash(input);
        
        return Convert.ToBase64String(output);
    }

    private string GenerateToken() => Guid.NewGuid().ToString();

    private async Task<int> CreateClientAsync(ClientBlank clientBlank, string token)
    {
        var client = new Models.Database.Client.Client(clientBlank);

        client.Token = token;
        
        if (client.Password != null)
            client.Password = Md5Password(client.Password);

        return await _clientRepository.AddClientAsync(client);
    }
    
    private async Task<int> CreateGuestAsync(string token)
    {
        var client = new Models.Database.Client.Client(){ Token = token };

        return await _clientRepository.AddClientAsync(client);
    }

    private bool PasswordValid(string password)
    {
        return password.Any(char.IsDigit) &&
               password.Any(char.IsLetter) &&
               password.Any(char.IsUpper) &&
               password.Any(char.IsLower) &&
               password.Any(char.IsPunctuation) &&
               password.Length >= 8;
    }
}