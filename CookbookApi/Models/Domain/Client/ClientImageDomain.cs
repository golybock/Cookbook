using CookbookApi.Models.Database.Client;

namespace CookbookApi.Models.Domain.Client;

public class ClientImageDomain
{
    public int ClientId { get; set; }
    
    public string Path { get; set; } = string.Empty;
    
    public DateTime DateOfAdded { get; set; }

    public ClientImageDomain() { }

    public ClientImageDomain(ClientImage clientImage)
    {
        Path = clientImage.Path;
        ClientId = clientImage.ClientId;
        DateOfAdded = clientImage.DateOfAdded;
    }
}