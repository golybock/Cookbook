using CookbookApi.Models.Blank.Client;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Services.Interfaces.AuthInterfaces;

public interface IAuthService
{
    public Task<IActionResult> Login(string login, string password);
    
    public Task<IActionResult> Registration(ClientBlank client);

    public Task<IActionResult> Guest();
}