using CookbookApi.Models.Database.Client;

namespace CookbookApi.Repositories.Interfaces.ClientInterfaces;

public interface IClientImageRepository
{
    public Task<ClientImage> GetClientImageAsync(int id);

    public Task<List<ClientImage>> GetClientImagesAsync(int clientId);
    
    public Task<List<ClientImage>> GetClientImagesAsync(int clientId, int limit);

    public Task<int> AddClientImageAsync(ClientImage clientImage);
    
    public Task<int> UpdateClientImageAsync(ClientImage clientImage);
    
    public Task<int> DeleteClientImageAsync(int id);
}