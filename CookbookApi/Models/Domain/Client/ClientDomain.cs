using CookbookApi.Models.Domain.Recipe;

namespace CookbookApi.Models.Domain.Client;

public class ClientDomain
{
    public string Login { get; set; } = null!;

    public string? Name { get; set; }

    public string? Description { get; set; }

    public List<ClientImageDomain> Images { get; set; } = new List<ClientImageDomain>();

    public List<RecipeDomain> Recipes { get; set; } = new List<RecipeDomain>();
}