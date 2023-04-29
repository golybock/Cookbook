using CookbookApi.Models.Database.Recipe.Ingredient;

namespace CookbookApi.Repositories.Interfaces.RecipeInterfaces.IngredientsInterfaces;

public interface IMeasureRepository
{
    public Task<Measure?> GetMeasureAsync(int id);
    
    public Task<List<Measure>> GetMeasuresAsync();
    
    public Task<int> AddMeasureAsync(Measure measure);
    
    public Task<int> UpdateMeasureAsync(Measure measure);
    
    public Task<int> DeleteMeasureAsync(int id);
}