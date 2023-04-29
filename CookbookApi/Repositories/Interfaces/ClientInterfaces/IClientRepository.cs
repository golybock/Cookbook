using ClientDb = CookbookApi.Models.Database.Client.Client;

namespace CookbookApi.Repositories.Interfaces.ClientInterfaces;

public interface IClientRepository
{
    public Task<ClientDb?> GetClientAsync(string token);
    
    public Task<ClientDb?> GetClientByLoginAsync(string login);

    public Task<int> AddClient(ClientDb client);

    public Task<int> UpdateClientAsync(int id, ClientDb client);

    public Task<int> UpdateToken(int id, string token);
    
    public Task<int> UpdateImage(int id, string image);
    
    public Task<int> UpdatePassword(int id, string password);
    
    public Task<int> DeleteClientAsync(int id);
}