using CookbookApi.Models.Database.Recipe.Ingredient;
using CookbookApi.Repositories.Interfaces.Recipe.Ingredient;
using Npgsql;

namespace CookbookApi.Repositories.Recipe.Ingredients;

public class IngredientRepository : RepositoryBase, IIngredientRepository
{
    public async Task<Ingredient?> GetIngredientAsync(int id)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from ingredient where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var ingredient = new Ingredient();
                ingredient.Id = reader.GetInt32(reader.GetOrdinal("id"));
                ingredient.MeasureId = reader.GetInt32(reader.GetOrdinal("measure_id"));
                ingredient.Name = reader.GetString(reader.GetOrdinal("name"));
                return ingredient;
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

    public async Task<List<Ingredient>> GetIngredientsAsync()
    {
        var ingredients = new List<Ingredient>();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from ingredient";

            await using var cmd = new NpgsqlCommand(query, con);

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var ingredient = new Ingredient();
                ingredient.Id = reader.GetInt32(reader.GetOrdinal("id"));
                ingredient.MeasureId = reader.GetInt32(reader.GetOrdinal("measure_id"));
                ingredient.Name = reader.GetString(reader.GetOrdinal("name"));

                ingredients.Add(ingredient);
            }

            return ingredients;
        }
        catch
        {
            return new List<Ingredient>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> AddIngredientAsync(Ingredient ingredient)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into ingredient(measure_id, name)" +
                        " values ($1, $2) returning id";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = ingredient.MeasureId},
                    new NpgsqlParameter {Value = ingredient.Name}
                }
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                ingredient.Id = reader.GetInt32(reader.GetOrdinal("id"));

            return ingredient.Id;
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

    public async Task<int> UpdateIngredientAsync(Ingredient ingredient)
    {
        var con = GetConnection();

        try
        {
            await con.OpenAsync();

            var query = "update ingredient set measure_id = $2, name = $3 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = ingredient.Id},
                    new NpgsqlParameter {Value = ingredient.MeasureId},
                    new NpgsqlParameter {Value = ingredient.Name}
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

    public async Task<int> DeleteIngredientAsync(int id)
    {
        return await DeleteAsync("ingredient", "id", id);
    }
}