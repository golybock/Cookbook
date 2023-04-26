using CookbookApi.Models.Blank.Client;
using CookbookApi.Models.Database.Client;
using CookbookApi.Models.Domain.Client;
using CookbookApi.Models.Domain.Recipe;
using Microsoft.AspNetCore.Mvc;
using ClientModel = CookbookApi.Models.Database.Client.Client;

namespace CookbookApi.Services.Interfaces.ClientInterfaces;

public interface IClientService
{
    public Task<ClientDomain> GetClientInfoAsync(string token);

    public Task<IActionResult> CreateClient(ClientBlank client);

    public Task<IActionResult> UpdateClientAsync(string token, ClientBlank client);
    
    public Task<IActionResult> DeleteClientAsync(string token);
    
    public Task<IActionResult> GetClientImageAsync(string token);

    public Task<IActionResult> GetClientImagesAsync(string token);
    
    public Task<IActionResult> GetClientImagesAsync(string token, int limit);

    public Task<IActionResult> UploadClientImageAsync(string token, IFormFile file);

    public Task<IActionResult> DeleteClientImageAsync(string token, int id);
    
    public Task<IActionResult> GetLikedRecipesAsync(string token);
    
    public Task<IActionResult> LikeRecipeAsync(string token, int recipeId);
    
    public Task<IActionResult> UnLikeRecipeAsync(string token, int recipeId);
}