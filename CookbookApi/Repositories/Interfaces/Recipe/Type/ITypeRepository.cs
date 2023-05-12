using TypeDatabase = Models.Database.Recipe.Type.Type;

namespace CookbookApi.Repositories.Interfaces.Recipe.Type;

public interface ITypeRepository
{
    public Task<TypeDatabase?> GetAsync(int id);
    public Task<List<TypeDatabase>> GetAsync();
}