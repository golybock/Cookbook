using CookbookApi.Models.Database.Recipe;
using CookbookApi.Repositories.Interfaces.RecipeInterfaces;
using Npgsql;

namespace CookbookApi.Repositories.Recipe;

public class RecipeStatsRepository : RepositoryBase, IRecipeStatsRepository
{
    public async Task<RecipeStats?> GetRecipeStatsAsync(int id)
    {
        var con = GetConnection();

        try
        {
            await con.OpenAsync();

            var query = "select * from recipe_stats where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var recipeStats = new RecipeStats();
                recipeStats.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipeStats.Squirrels = reader.GetDecimal(reader.GetOrdinal("squirrels"));
                recipeStats.Fats = reader.GetDecimal(reader.GetOrdinal("fats"));
                recipeStats.Carbohydrates = reader.GetDecimal(reader.GetOrdinal("carbohydrates"));
                recipeStats.Kilocalories = reader.GetDecimal(reader.GetOrdinal("kilocalories"));
                recipeStats.Portions = reader.GetInt32(reader.GetOrdinal("portions"));
                recipeStats.CookingTime = reader.GetDateTime(reader.GetOrdinal("cooking_time"));
                return recipeStats;
            }

            return null;
        }
        catch (Exception e)
        {
            return null;
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> AddRecipeStatsAsync(RecipeStats recipeStats)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into recipe_stats(id, squirrels, fats, carbohydrates, kilocalories)" +
                        " values ($1, $2, $3, $4, $5)";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipeStats.Id},
                    new NpgsqlParameter {Value = recipeStats.Squirrels},
                    new NpgsqlParameter {Value = recipeStats.Fats},
                    new NpgsqlParameter {Value = recipeStats.Carbohydrates},
                    new NpgsqlParameter {Value = recipeStats.Kilocalories}
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

    public async Task<int> UpdateRecipeStatsAsync(RecipeStats recipeStats)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query =
                "update recipe_stats set squirrels = $2, fats = $3, carbohydrates = $4, kilocalories = $5 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipeStats.Id},
                    new NpgsqlParameter {Value = recipeStats.Squirrels},
                    new NpgsqlParameter {Value = recipeStats.Fats},
                    new NpgsqlParameter {Value = recipeStats.Carbohydrates},
                    new NpgsqlParameter {Value = recipeStats.Kilocalories}
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

    public async Task<int> DeleteRecipeStatsAsync(int id)
    {
        var connection = GetConnection();

        try
        {
            connection.Open();

            var query = "delete from recipe_stats where id = $1";
            await using var cmd = new NpgsqlCommand(query, connection)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = id}
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
            await connection.CloseAsync();
        }
    }
}