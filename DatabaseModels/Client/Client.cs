namespace DatabaseModels.Client;

public class Client
{
    public int Id { get; set; }

    public int RoleId { get; set; }
    
    public string Login { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;
    
    public string? Description { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public string? Email { get; set; }
    
    public string? ImagePath { get; set; }
}