using CookbookApi.Models.Blank.Client;
using CookbookApi.Services.Interfaces.AuthInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Auth;

public class AuthService : IAuthService
{
    public async Task<IActionResult> Login(string login, string password)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Registration(ClientBlank client)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdatePassword(string token, string password, string newPassword)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> Guest()
    {
        throw new NotImplementedException();
    }
}