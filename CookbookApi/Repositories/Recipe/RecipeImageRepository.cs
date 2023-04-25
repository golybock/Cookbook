using CookbookApi.Models.Database.Recipe;
using CookbookApi.Repositories.Interfaces.RecipeInterfaces;
using Npgsql;

namespace CookbookApi.Repositories.Recipe;

public class RecipeImageRepository : RepositoryBase, IRecipeImageRepository
{
    public async Task<RecipeImage> GetRecipeImageAsync(int id)
    {
        var recipeImage = new RecipeImage();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from recipe_images where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                recipeImage.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipeImage.RecipeId = reader.GetInt32(reader.GetOrdinal("recipe_id"));
                recipeImage.Path = reader.GetString(reader.GetOrdinal("image_path"));
            }

            return recipeImage;
        }
        catch
        {
            return new RecipeImage();
        }
        finally
        {
            await con.CloseAsync();
        }
    }
    public async Task<List<RecipeImage>> GetRecipeImagesAsync(int recipeId)
    {
        var recipeImages = new List<RecipeImage>();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from recipe_images where recipe_id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = recipeId}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var recipeImage = new RecipeImage();

                recipeImage.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipeImage.RecipeId = reader.GetInt32(reader.GetOrdinal("recipe_id"));
                recipeImage.Path = reader.GetString(reader.GetOrdinal("image_path"));

                recipeImages.Add(recipeImage);
            }

            return recipeImages;
        }
        catch
        {
            return new List<RecipeImage>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> AddRecipeImageAsync(RecipeImage recipeImage)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into recipe_images(recipe_id, path)" +
                        " values ($1, $2) returning id";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipeImage.RecipeId},
                    new NpgsqlParameter {Value = recipeImage.Path}
                }
            };
            
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync()) recipeImage.Id = reader.GetInt32(reader.GetOrdinal("id"));

            return recipeImage.Id;
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

    public async Task<int> UpdateRecipeImageAsync(RecipeImage recipeImage)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update recipe_images set path = $2 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipeImage.Id},
                    new NpgsqlParameter {Value = recipeImage.Path}
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

    public async Task<int> DeleteRecipeImagesAsync(int recipeId)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "delete from recipe_images where recipe_id = $1";

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

    public async Task<int> DeleteRecipeImageAsync(int id)
    {
        return await DeleteAsync("recipe_images", "id", id.ToString());
    }
}