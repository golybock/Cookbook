using System.Collections.Generic;
using System.Threading.Tasks;
using CookbookApi.Models.Database;
using CookbookApi.Models.Database.Recipe;
using CookbookApi.Models.Database.Recipe.Category;

namespace Cookbook.Database.Services.Interfaces.RecipeInterfaces;

public interface ICategoryService
{
    public Task<Category> GetCategoryAsync(int id);
    public Task<List<Category>> GetCategories();
    public Task<CommandResult> AddCategoryAsync(Category category);
    public Task<CommandResult> UpdateCategoryAsync(Category category);
    public Task<CommandResult> DeleteCategoryAsync(int id);
}