using CookbookApi.Models.Blank.Client;
using CookbookApi.Models.Domain.Client;
using ClientModel = CookbookApi.Models.Database.Client.Client;

namespace CookbookApi.Services.Interfaces.ClientInterfaces;

public interface IClientService
{
    public Task<ClientDomain> GetClientInfoAsync(string token);

    public Task<int> CreateClient(ClientBlank client);

    public Task<int> UpdateClientAsync(string token, ClientBlank client);
    
    public Task<int> DeleteClientAsync(string token);
}