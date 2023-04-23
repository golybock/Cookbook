using CookbookApi.Models.Database.Recipe.Ingredient;

namespace CookbookApi.Repositories.Interfaces.RecipeInterfaces.IngredientsInterfaces;

public interface IIngredientRepository
{
    public Task<Ingredient> GetIngredientAsync(int id);
    
    public Task<List<Ingredient>> GetIngredientsAsync();
    
    public Task<int> AddIngredientAsync(Ingredient ingredient);
    
    public Task<int> UpdateIngredientAsync(Ingredient ingredient);
    
    public Task<int> DeleteIngredientAsync(int id);
}