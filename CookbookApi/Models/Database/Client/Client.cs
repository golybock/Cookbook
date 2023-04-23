namespace CookbookApi.Models.Database.Client;

public partial class Client
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Token { get; set; } = string.Empty;

    public string? Name { get; set; }

    public string? Description { get; set; }
}