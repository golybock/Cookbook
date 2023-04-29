using CookbookApi.Models.Database.Recipe.Category;
using CookbookApi.Repositories.Interfaces.RecipeInterfaces;
using Npgsql;

namespace CookbookApi.Repositories.Recipe;

public class RecipeCategoryRepository : RepositoryBase, IRecipeCategoryRepository
{
    public async Task<RecipeCategory?> GetRecipeCategoryAsync(int id)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from recipe_categories where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var recipeCategory = new RecipeCategory();
                recipeCategory.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipeCategory.RecipeId = reader.GetInt32(reader.GetOrdinal("recipe_id"));
                recipeCategory.CategoryId = reader.GetInt32(reader.GetOrdinal("category_id"));
                return recipeCategory;
            }

            return null;
        }
        catch
        {
            return null;
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<List<RecipeCategory>> GetRecipeCategoriesAsync(int recipeId)
    {
        var recipeCategories = new List<RecipeCategory>();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from recipe_categories where recipe_id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = recipeId}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var recipeCategory = new RecipeCategory();

                recipeCategory.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipeCategory.RecipeId = reader.GetInt32(reader.GetOrdinal("recipe_id"));
                recipeCategory.CategoryId = reader.GetInt32(reader.GetOrdinal("category_id"));

                recipeCategories.Add(recipeCategory);
            }

            return recipeCategories;
        }
        catch
        {
            return new List<RecipeCategory>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> AddRecipeCategoryAsync(RecipeCategory recipeCategory)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into recipe_categories(recipe_id, category_id)" +
                        " values ($1, $2) returning id";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipeCategory.RecipeId},
                    new NpgsqlParameter {Value = recipeCategory.CategoryId}
                }
            };
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync()) recipeCategory.Id = reader.GetInt32(reader.GetOrdinal("id"));

            return recipeCategory.Id;
        }
        catch (Exception e)
        {
            return -1;
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> UpdateRecipeCategoryAsync(RecipeCategory recipeCategory)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update recipe_categories set recipe_id = $2, category_id = $3 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipeCategory.Id},
                    new NpgsqlParameter {Value = recipeCategory.RecipeId},
                    new NpgsqlParameter {Value = recipeCategory.CategoryId}
                }
            };
            
            return await cmd.ExecuteNonQueryAsync();
        }
        catch (Exception e)
        {
            return -1;
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> DeleteRecipeCategoryAsync(int id)
    {
        return await DeleteAsync("recipe_categories", "id", id.ToString());
    }

    public async Task<int> DeleteRecipeCategoriesAsync(int recipeId)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "delete from recipe_categories where recipe_id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipeId}
                }
            };
            
            return await cmd.ExecuteNonQueryAsync();
        }
        catch (Exception e)
        {
            return -1;
        }
        finally
        {
            await con.CloseAsync();
        }
    }
}