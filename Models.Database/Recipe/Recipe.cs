namespace Models.Database.Recipe;

public class Recipe
{
    public int Id { get; set; }

    public int OwnerClientId { get; set; }
    
    public string? Code { get; set; }

    public string Header { get; set; } = string.Empty;
}