using ClientDb = CookbookApi.Models.Database.Client.Client;

namespace CookbookApi.Repositories.Interfaces.ClientInterfaces;

public interface IClientRepository
{
    public Task<ClientDb?> GetClientAsync(string token);
    
    public Task<ClientDb?> GetClientByLoginAsync(string login);

    public Task<int> AddClientAsync(ClientDb client);

    public Task<int> UpdateClientAsync(int id, ClientDb client);

    public Task<int> UpdateTokenAsync(int id, string token);
    
    public Task<int> UpdateImageAsync(int id, string image);
    
    public Task<int> UpdatePasswordAsync(int id, string password);
    
    public Task<int> DeleteClientAsync(int id);

    public Task<int> DeleteClientImageAsync(int id);
}