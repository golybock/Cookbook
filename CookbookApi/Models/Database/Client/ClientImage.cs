using CookbookApi.Models.Domain.Client;

namespace CookbookApi.Models.Database.Client;

public class ClientImage
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public string Path { get; set; } = string.Empty;
    
    public DateTime DateOfAdded { get; set; }

    public ClientImage() { }

    public ClientImage(ClientImageDomain clientImage)
    {
        Path = clientImage.Path;
        DateOfAdded = clientImage.DateOfAdded;
    }

    public ClientImage(ClientImage clientImage)
    {
        Path = clientImage.Path;
        DateOfAdded = clientImage.DateOfAdded;
    }
}