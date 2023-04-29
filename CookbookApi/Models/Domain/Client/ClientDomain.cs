using CookbookApi.Models.Blank.Client;
using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Domain.Client;

public class ClientDomain
{
    public string? Login { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<RecipeDomain> Recipes { get; set; } = new List<RecipeDomain>();
    
    public string? Email { get; set; }
    
    public string? ImagePath { get; set; }
    
    public ClientDomain() { }

    public ClientDomain(Database.Client.Client client)
    {
        Login = client.Login;
        Name = client.Name;
        Email = client.Email;
        ImagePath = client.ImagePath;
        Description = client.Description;
    }
    
    public ClientDomain(ClientBlank client)
    {
        Login = client.Login;
        Name = client.Name;
        Email = client.Email;
        Description = client.Description;
    }
}