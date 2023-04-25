using CookbookApi.Models.Database.Recipe;
using CookbookApi.Repositories.Interfaces.RecipeInterfaces;
using Npgsql;

namespace CookbookApi.Repositories.Recipe;

public class RecipeIngredientRepository : RepositoryBase, IRecipeIngredientRepository
{
    public async Task<RecipeIngredient> GetRecipeIngredientAsync(int id)
    {
        var recipeIngredient = new RecipeIngredient();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from recipe_ingredients where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                recipeIngredient.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipeIngredient.RecipeId = reader.GetInt32(reader.GetOrdinal("recipe_id"));
                recipeIngredient.IngredientId = reader.GetInt32(reader.GetOrdinal("ingredient_id"));
                recipeIngredient.Count = reader.GetInt32(reader.GetOrdinal("count"));
            }

            return recipeIngredient;
        }
        catch
        {
            return new RecipeIngredient();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<List<RecipeIngredient>> GetRecipeIngredientsAsync(int recipeId)
    {
        var con = GetConnection();
        con.Open();
        var recipeIngredients = new List<RecipeIngredient>();
        try
        {
            var query = "select * from recipe_ingredients where recipe_id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = recipeId}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var recipeIngredient = new RecipeIngredient();

                recipeIngredient.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipeIngredient.RecipeId = reader.GetInt32(reader.GetOrdinal("recipe_id"));
                recipeIngredient.IngredientId = reader.GetInt32(reader.GetOrdinal("ingredient_id"));
                recipeIngredient.Count = reader.GetInt32(reader.GetOrdinal("count"));

                recipeIngredients.Add(recipeIngredient);
            }

            return recipeIngredients;
        }
        catch
        {
            return new List<RecipeIngredient>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> AddRecipeIngredientAsync(RecipeIngredient recipeIngredient)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into recipe_ingredients(recipe_id, ingredient_id, count)" +
                        " values ($1, $2, $3) returning id";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipeIngredient.RecipeId},
                    new NpgsqlParameter {Value = recipeIngredient.IngredientId},
                    new NpgsqlParameter {Value = recipeIngredient.Count}
                }
            };
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync()) recipeIngredient.Id = reader.GetInt32(reader.GetOrdinal("id"));

            return recipeIngredient.Id;
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

    public async Task<int> UpdateRecipeIngredientAsync(RecipeIngredient recipeIngredient)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update recipe_ingredients set count = $2 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipeIngredient.Id},
                    new NpgsqlParameter {Value = recipeIngredient.Count}
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

    public async Task<int> DeleteRecipeIngredientAsync(int id)
    {
        return await DeleteAsync("recipe_ingredients", "id", id.ToString());
    }

    public async Task<int> DeleteRecipeIngredientsAsync(int recipeId)
    {
        return await DeleteAsync("recipe_ingredients", "recipe_id", recipeId.ToString());
    }

}