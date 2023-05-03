using Domain.Client;

namespace Database.Client;

public partial class Client
{
    public int Id { get; set; }

    public string? Login { get; set; } = null!;

    public string? Password { get; set; } = null!;

    public string Token { get; set; } = string.Empty;

    public string? Name { get; set; }

    public string? Description { get; set; }
    
    public string? ImagePath { get; set; }
    
    public string? Email { get; set; }

    public Client()  { }

    public Client(ClientDomain client)
    {
        Login = client.Login;
        Name = client.Name;
        Email = client.Email;
        ImagePath = client.ImagePath;
        Description = client.Description;
    }
    
    public Client(ClientBlank client)
    {
        Login = client.Login;
        Password = client.Password;
        Name = client.Name;
        Email = client.Email;
        Description = client.Description;
    }
    
}