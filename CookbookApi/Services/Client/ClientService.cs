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

    public async Task<IActionResult> UpdateClientAsync(string token, ClientBlank clientBlank)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var blank = new ClientModel(clientBlank);

        var res = await _clientRepository.UpdateClientAsync(client.Id, blank);

        return res > 0 ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteClientAsync(string token)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var res = await _clientRepository.DeleteClientAsync(client.Id);

        return res > 0 ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> GetClientImageAsync(string token)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        if (client.ImagePath == null)
            return new NotFoundResult();
        
        return new OkObjectResult(client.ImagePath);
    }
    
    public async Task<IActionResult> UploadClientImageAsync(string token, IFormFile file)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var path = await SaveImageAsync(file);

        var res = await _clientRepository.UpdateImageAsync(client.Id, path);

        return res > 0 ? new OkObjectResult(path) : new BadRequestResult();
    }

    public async Task<IActionResult> DeleteClientImageAsync(string token)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var res = await _clientRepository.DeleteClientImageAsync(client.Id);

        return res > 0 ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> GetLikedRecipesAsync(string token)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var likedRecipes = await _clientFavRepository.GetFavoriteRecipesAsync(client.Id);

        if (likedRecipes.Count == 0)
            return new NotFoundResult();
        
        List<RecipeDomain> recipes = new List<RecipeDomain>();

        foreach (var likedRecipe in likedRecipes)
        {
            var recipe = await _recipeRepository.GetRecipeAsync(likedRecipe.RecipeId);

            if (recipe != null)
            {
                RecipeDomain recipeDomain = new RecipeDomain(recipe);

                recipeDomain.IsLiked = true;
                
                recipes.Add(recipeDomain);
            }
        }

        return new OkObjectResult(recipes);
    }

    public async Task<IActionResult> LikeRecipeAsync(string token, int recipeId)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();

        var recipe = await _recipeRepository.GetRecipeAsync(recipeId);

        if (recipe == null)
            return new NotFoundObjectResult("Рецепт не найден");

        var favRecipe = new FavoriteRecipe()
        {
            ClientId = client.Id,
            RecipeId = recipe.Id
        };

        var res = await _clientFavRepository.AddFavoriteRecipeAsync(favRecipe);

        return res > 0 ? new OkResult() : new BadRequestResult();
    }

    public async Task<IActionResult> UnLikeRecipeAsync(string token, int recipeId)
    {
        var client = await _clientRepository.GetClientAsync(token);

        if (client == null)
            return new UnauthorizedResult();
        
        var res = await _clientFavRepository.DeleteFavoriteRecipeAsync(client.Id, recipeId);
        
        return res > 0 ? new OkResult() : new NotFoundResult();
    }

    private async Task<string> SaveImageAsync(IFormFile file)
    {
        string directory = "wwwroot/ClientImages/";
        
        string path = $"{Guid.NewGuid()}.png";

        using StreamWriter sw = new StreamWriter(directory + path);
        
        await file.CopyToAsync(sw.BaseStream);

        return path;
    }
}