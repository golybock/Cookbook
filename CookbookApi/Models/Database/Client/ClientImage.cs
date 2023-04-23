namespace CookbookApi.Models.Database.Client;

public class ClientImage
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public string Path { get; set; } = string.Empty;
    
    public DateTime DateOfAdded { get; set; }
}