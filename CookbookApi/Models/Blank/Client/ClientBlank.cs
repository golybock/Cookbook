using CookbookApi.Models.Domain.Client;

namespace CookbookApi.Models.Blank.Client;

public class ClientBlank
{
    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public ClientBlank() { }

    public ClientBlank(Database.Client.Client client)
    {
        Login = client.Login;
        Name = client.Name;
        Description = client.Description;
    }

    public ClientBlank(ClientDomain client)
    {
        Login = client.Login;
        Name = client.Name;
        Description = client.Description;
    }
}