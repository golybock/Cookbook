using ClientDb = CookbookApi.Models.Database.Client.Client;

namespace CookbookApi.Repositories.Interfaces.ClientInterfaces;

public interface IClientRepository
{
    public Task<ClientDb> GetClientAsync(int id);

    public Task<int> AddClient(ClientDb client);

    public Task<int> UpdateClientAsync(int id, ClientDb client);
    public Task<int> DeleteClientAsync(int id);
}