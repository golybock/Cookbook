using CookbookApi.Models.Blank.Client;
using CookbookApi.Services.Client;
using CookbookApi.Services.Interfaces.ClientInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Controllers.Client
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase, IClientService
    {
        private readonly ClientService _clientService;

        public ClientController()
        {
            _clientService = new ClientService();
        }

        [HttpGet("Client")]
        public async Task<IActionResult> GetClientInfoAsync([FromHeader] string token)
        {
            return await _clientService.GetClientInfoAsync(token);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateClientAsync([FromHeader] string token, ClientBlank client)
        {
            return await _clientService.UpdateClientAsync(token, client);
        }

        [HttpDelete("DeleteClient")]
        public async Task<IActionResult> DeleteClientAsync([FromHeader] string token)
        {
            return await _clientService.DeleteClientAsync(token);
        }

        [HttpGet("ClientImage")]
        public async Task<IActionResult> GetClientImageAsync([FromHeader] string token)
        {
            return await _clientService.GetClientImageAsync(token);
        }

        [HttpPost("ClientImage")]
        public async Task<IActionResult> UploadClientImageAsync([FromHeader] string token, IFormFile file)
        {
            return await _clientService.UploadClientImageAsync(token, file);
        }

        [HttpDelete("ClientImage")]
        public async Task<IActionResult> DeleteClientImageAsync([FromHeader] string token)
        {
            return await _clientService.DeleteClientImageAsync(token);
        }

        [HttpGet("LikedRecipes")]
        public async Task<IActionResult> GetLikedRecipesAsync([FromHeader] string token)
        {
            return await _clientService.GetLikedRecipesAsync(token);
        }

        [HttpPost("Like")]
        public async Task<IActionResult> LikeRecipeAsync([FromHeader] string token, int recipeId)
        {
            return await _clientService.LikeRecipeAsync(token, recipeId);
        }

        [HttpPost("UnLike")]
        public async Task<IActionResult> UnLikeRecipeAsync([FromHeader] string token, int recipeId)
        {
            return await _clientService.UnLikeRecipeAsync(token, recipeId);
        }
    }
}
