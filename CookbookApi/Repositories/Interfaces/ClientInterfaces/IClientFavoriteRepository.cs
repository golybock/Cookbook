using CookbookApi.Models.Database.Client;
using Microsoft.AspNetCore.Mvc;

namespace CookbookApi.Repositories.Interfaces.ClientInterfaces;

public interface IClientFavoriteRepository
{
    public Task<FavoriteRecipe?> GetFavoriteRecipeAsync(int id);

    public Task<List<FavoriteRecipe>> GetFavoriteRecipesAsync(int clientId);


    public Task<int> AddFavoriteRecipeAsync(FavoriteRecipe favoriteRecipe);
    
    // delete fav_recipe where id == id
    public Task<int> DeleteFavoriteRecipeAsync(int id);

    // delete fav_recipe where recipe_id == recipeId and client_id == clientId
    public Task<int> DeleteFavoriteRecipeAsync(int recipeId, int clientId); 

    // delete fav_recipe where recipe_id == recipeId
    public Task<int> DeleteRecipeFromFavoritesAsync(int recipeId); 

    // delete fav_recipe where client_id == clientId
    public Task<int> DeleteClientFavoriteRecipes(int clientId); 
}