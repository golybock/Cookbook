using CookbookApi.Models.Database.Recipe;
using CookbookApi.Repositories.Interfaces.RecipeInterfaces;
using Npgsql;

namespace CookbookApi.Repositories.Recipe;

public class RecipeStepRepository : RepositoryBase, IRecipeStepRepository
{
    public async Task<RecipeStep?> GetRecipeStep(int id)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from recipe_step where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var recipeStep = new RecipeStep();

                recipeStep.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipeStep.RecipeId = reader.GetInt32(reader.GetOrdinal("recipe_id"));
                recipeStep.Text = reader.GetString(reader.GetOrdinal("text"));
                
                return recipeStep;
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

    public async Task<List<RecipeStep>> GetRecipeSteps(int recipeId)
    {
        List<RecipeStep> recipeSteps = new List<RecipeStep>();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from recipe_step where recipe_id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = recipeId}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var recipeStep = new RecipeStep();

                recipeStep.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipeStep.RecipeId = reader.GetInt32(reader.GetOrdinal("recipe_id"));
                recipeStep.Text = reader.GetString(reader.GetOrdinal("text"));
                
                recipeSteps.Add(recipeStep);
            }

            return recipeSteps;
        }
        catch
        {
            return new List<RecipeStep>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> AddRecipeStep(RecipeStep recipeStep)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into recipe_step(recipe_id, number, text)" +
                        " VALUES ($1, $2, $3)" +
                        " returning id";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipeStep.RecipeId},
                    new NpgsqlParameter {Value = recipeStep.Number == 0 ? DBNull.Value : recipeStep.Number},
                    new NpgsqlParameter {Value = recipeStep.Text}
                }
            };
            
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                recipeStep.Id = reader.GetInt32(reader.GetOrdinal("id"));
            }

            return recipeStep.Id;
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

    public async Task<int> DeleteRecipeStep(int id)
    {
        return await DeleteAsync("recipe_step", "id", id);
    }

    public async Task<int> DeleteRecipeSteps(int recipeId)
    {
        return await DeleteAsync("recipe_step", "recipe_id", recipeId);
    }
}