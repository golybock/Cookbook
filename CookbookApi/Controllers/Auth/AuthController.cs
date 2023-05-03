using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blank.Client;
using CookbookApi.Services.Auth;
using CookbookApi.Services.Interfaces.AuthInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase, IAuthService
    {
        private readonly AuthService _authService;

        public AuthController()
        {
            _authService = new AuthService();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromHeader] string login, [FromHeader] string password)
        {
            return await _authService.Login(login, password);
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(ClientBlank client)
        {
            return await _authService.Registration(client);
        }
        
        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromHeader] string token, string password, string newPassword)
        {
            return await _authService.UpdatePassword(token, password, newPassword);
        }

        [HttpPost("Guest")]
        public async Task<IActionResult> Guest()
        {
            return await _authService.Guest();
        }
    }
}
