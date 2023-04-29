using CookbookApi.Models.Database.Recipe.Category;
using CookbookApi.Repositories.Interfaces.RecipeInterfaces;
using Npgsql;

namespace CookbookApi.Repositories.Recipe;

public class CategoryRepository : RepositoryBase, ICategoryRepository
{
    public async Task<Category?> GetCategoryAsync(int id)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from category where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var category = new Category();
                category.Id = reader.GetInt32(reader.GetOrdinal("id"));
                category.Name = reader.GetString(reader.GetOrdinal("name"));
                return category;
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

    public async Task<List<Category>> GetCategoriesAsync()
    {
        var categories = new List<Category>();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from category";

            await using var cmd = new NpgsqlCommand(query, con);

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var category = new Category();

                category.Id = reader.GetInt32(reader.GetOrdinal("id"));
                category.Name = reader.GetString(reader.GetOrdinal("name"));

                categories.Add(category);
            }

            return categories;
        }
        catch
        {
            return new List<Category>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> AddCategoryAsync(Category category)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into category(name) values ($1) returning id";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = category.Name}
                }
            };
            
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync()) category.Id = reader.GetInt32(reader.GetOrdinal("id"));

            return category.Id;
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

    public async Task<int> UpdateCategoryAsync(Category category)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update category set name = $2 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = category.Id},
                    new NpgsqlParameter {Value = category.Name}
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

    public async Task<int> DeleteCategoryAsync(int id)
    {
        return await DeleteAsync("category", "id", id.ToString());
    }
}