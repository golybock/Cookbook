using IngredientDatabase = Models.Database.Recipe.Ingredient.Ingredient;

namespace CookbookApi.Repositories.Interfaces.Recipe.Ingredient;

public interface IIngredientRepository
{
    public Task<IngredientDatabase?> GetAsync(int id);
    
    public Task<List<IngredientDatabase>> GetAsync();
    
    public Task<int> AddAsync(IngredientDatabase ingredient);
    
    public Task<int> UpdateAsync(IngredientDatabase ingredient);
    
    public Task<int> DeleteAsync(int id);
}