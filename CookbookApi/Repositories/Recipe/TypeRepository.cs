using CookbookApi.Models.Database.Recipe;
using CookbookApi.Repositories.Interfaces.Recipe.Type;
using CookbookApi.Repositories.Interfaces.RecipeInterfaces;
using Npgsql;

namespace CookbookApi.Repositories.Recipe;

public class TypeRepository : RepositoryBase, ITypeRepository
{
    public async Task<RecipeType?> GetRecipeTypeAsync(int id)
    {
        var con = GetConnection();
        
        try
        {
            await con.OpenAsync();
            var query = "select * from recipe_type where id = $1";
            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var recipeType = new RecipeType();
                recipeType.Id = id;
                recipeType.Name = reader.GetString(reader.GetOrdinal("name"));
                return recipeType;
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

    public async Task<List<RecipeType>> GetRecipeTypesAsync()
    {
        var con = GetConnection();
        var recipeTypes = new List<RecipeType>();
        try
        {
            await con.OpenAsync();
            var query = "select * from recipe_type";

            await using var cmd = new NpgsqlCommand(query, con);

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var recipeType = new RecipeType();
                recipeType.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipeType.Name = reader.GetString(reader.GetOrdinal("name"));
                recipeTypes.Add(recipeType);
            }

            return recipeTypes;
        }
        catch
        {
            return new List<RecipeType>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }
}