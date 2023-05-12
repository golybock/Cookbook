using MeasureDatabase = Models.Database.Recipe.Ingredient.Measure;

namespace CookbookApi.Repositories.Interfaces.Recipe.Ingredient;

public interface IMeasureRepository
{
    public Task<MeasureDatabase?> GetAsync(int id);
    
    public Task<List<MeasureDatabase>> GetAsync();
    
    public Task<int> AddAsync(MeasureDatabase measure);

    public Task<int> DeleteAsync(int id);
}