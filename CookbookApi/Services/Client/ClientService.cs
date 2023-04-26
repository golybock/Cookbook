using CookbookApi.Models.Blank.Client;
using CookbookApi.Models.Database.Client;
using CookbookApi.Models.Domain.Client;
using CookbookApi.Services.Interfaces.ClientInterfaces;
using Microsoft.AspNetCore.Mvc;
using ClientModel = CookbookApi.Models.Database.Client.Client;

namespace CookbookApi.Services.Client;

public class ClientService : IClientService
{
    public async Task<ClientDomain> GetClientInfoAsync(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> CreateClient(ClientBlank client)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UpdateClientAsync(string token, ClientBlank client)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteClientAsync(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetClientImageAsync(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetClientImagesAsync(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetClientImagesAsync(string token, int limit)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UploadClientImageAsync(string token, IFormFile file)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteClientImageAsync(string token, int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> GetLikedRecipesAsync(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> LikeRecipeAsync(string token, int recipeId)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> UnLikeRecipeAsync(string token, int recipeId)
    {
        throw new NotImplementedException();
    }
}