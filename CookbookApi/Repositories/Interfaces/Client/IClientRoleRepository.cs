using Models.Database.Client;

namespace CookbookApi.Repositories.Interfaces.Client;

public interface IClientRoleRepository
{
    public Task<ClientRole?> GetAsync(int id);
    
    public Task<List<ClientRole>> GetAsync();
}