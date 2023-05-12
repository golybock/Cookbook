using ClientDatabase = Models.Database.Client.Client;

namespace CookbookApi.Repositories.Interfaces.Client;

public interface IClientRepository
{
    public Task<ClientDatabase?> GetAsync(int id);
    
    public Task<ClientDatabase?> GetAsync(string login);

    public Task<int> AddAsync(ClientDatabase client);

    public Task<int> UpdateAsync(int id, ClientDatabase client);

    public Task<int> UpdateImageAsync(int id, string image);
    
    public Task<int> UpdatePasswordAsync(int id, string passwordHash);
    
    public Task<int> DeleteAsync(int id);

    public Task<int> DeleteClientImageAsync(int id);
}