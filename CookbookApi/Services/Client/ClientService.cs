using CookbookApi.Models.Blank.Client;
using CookbookApi.Models.Database.Client;
using CookbookApi.Models.Domain.Client;
using CookbookApi.Models.Domain.Recipe;
using CookbookApi.Repositories.Client;
using CookbookApi.Repositories.Recipe;
using CookbookApi.Services.Interfaces.ClientInterfaces;
using Microsoft.AspNetCore.Mvc;
using ClientModel = CookbookApi.Models.Database.Client.Client;

namespace CookbookApi.Services.Client;

public class ClientService : IClientService
{
    private readonly ClientRepository _clientRepository;
    private readonly ClientFavRepository _clientFavRepository;
    private readonly RecipeRepository _recipeRepository;
    
    public ClientService()
    {
        _recipeRepository = new RecipeRepository();
        _clientFavRepository = new ClientFavRepository();
        _clientRepository = new ClientRepository();
    }

    public async Task<IActionResult> GetClientInfoAsync(string token)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var clientDomain = new ClientDomain(client);

        var recipes = await _recipeRepository.GetClientRecipesAsync(client.Id);

        clientDomain.Recipes = recipes.Select(c => new RecipeDomain(c)).ToList();

        return new OkObjectResult(clientDomain);
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
    
    public async Task<IActionResult> UploadClientImageAsync(string token, IFormFile file)
    {
        throw new NotImplementedException();
    }

    public async Task<IActionResult> DeleteClientImageAsync(string token)
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