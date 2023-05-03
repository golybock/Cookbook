namespace Database.Recipe;

public class RecipeType
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public RecipeType() { }

    public RecipeType(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public RecipeType(RecipeTypeBlank recipeType)
    {
        Name = recipeType.Name;
    }
    
    public RecipeType(RecipeTypeDomain recipeType)
    {
        Id = recipeType.Id;
        Name = recipeType.Name;
    }
}