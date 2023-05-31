using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Database;

namespace Cookbook.Services;

public interface IRecipeService
{
    public Task<Recipe?> Get(int id);

    public Task<List<Recipe>> Get();

    public Task<int> Create(Recipe recipe, string? image);

    public Task Update(Recipe recipe, string? image);

    public Task Delete(Recipe recipe);
}