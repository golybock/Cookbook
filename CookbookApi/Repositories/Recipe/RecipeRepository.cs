using CookbookApi.Repositories.Interfaces.RecipeInterfaces;
using Npgsql;
using RecipeModel = CookbookApi.Models.Database.Recipe.Recipe;

namespace CookbookApi.Repositories.Recipe;

public class RecipeRepository : RepositoryBase, IRecipeRepository
{
    public async Task<RecipeModel?> GetRecipeAsync(int id)
    {
        var recipe = new RecipeModel();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from recipe where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                recipe.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipe.ClientId = reader.GetInt32(reader.GetOrdinal("client_id"));
                recipe.TypeId = reader.GetInt32(reader.GetOrdinal("type_id"));
                recipe.Header = reader.GetString(reader.GetOrdinal("header"));
                
                var imagePath = reader.GetValue(reader.GetOrdinal("image_path"));
                recipe.ImagePath = imagePath == DBNull.Value ? null : imagePath.ToString();

                var source = reader.GetValue(reader.GetOrdinal("source_url"));
                recipe.SourceUrl = source == DBNull.Value ? null : source.ToString();
                
                var description = reader.GetValue(reader.GetOrdinal("description"));
                recipe.Description = description == DBNull.Value ? null : description.ToString();
                
                recipe.Code = reader.GetString(reader.GetOrdinal("code"));
            }

            return recipe;
        }
        catch
        {
            return new RecipeModel();
        }
        finally
        {
            await con.CloseAsync();
        }
    }
    
    public async Task<RecipeModel?> GetRecipeAsync(string recipeCode)
    {
        var recipe = new RecipeModel();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from recipe where code = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = recipeCode}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                recipe.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipe.ClientId = reader.GetInt32(reader.GetOrdinal("client_id"));
                recipe.TypeId = reader.GetInt32(reader.GetOrdinal("type_id"));
                recipe.Header = reader.GetString(reader.GetOrdinal("header"));
                
                var imagePath = reader.GetValue(reader.GetOrdinal("image_path"));
                recipe.ImagePath = imagePath == DBNull.Value ? null : imagePath.ToString();

                var source = reader.GetValue(reader.GetOrdinal("source_url"));
                recipe.SourceUrl = source == DBNull.Value ? null : source.ToString();
                
                var description = reader.GetValue(reader.GetOrdinal("description"));
                recipe.Description = description == DBNull.Value ? null : description.ToString();
                
                recipe.Code = reader.GetString(reader.GetOrdinal("code"));
            }

            return recipe;
        }
        catch
        {
            return new RecipeModel();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<List<RecipeModel>> GetRecipesAsync()
    {
        var recipes = new List<RecipeModel>();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from recipe";

            await using var cmd = new NpgsqlCommand(query, con);

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var recipe = new RecipeModel();

                recipe.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipe.ClientId = reader.GetInt32(reader.GetOrdinal("client_id"));
                recipe.TypeId = reader.GetInt32(reader.GetOrdinal("type_id"));
                recipe.Header = reader.GetString(reader.GetOrdinal("header"));
                
                var imagePath = reader.GetValue(reader.GetOrdinal("image_path"));
                recipe.ImagePath = imagePath == DBNull.Value ? null : imagePath.ToString();

                var source = reader.GetValue(reader.GetOrdinal("source_url"));
                recipe.SourceUrl = source == DBNull.Value ? null : source.ToString();
                
                var description = reader.GetValue(reader.GetOrdinal("description"));
                recipe.Description = description == DBNull.Value ? null : description.ToString();
                
                recipe.Code = reader.GetString(reader.GetOrdinal("code"));
                
                recipes.Add(recipe);
            }

            return recipes;
        }
        catch
        {
            return new List<RecipeModel>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<List<RecipeModel>> GetClientRecipesAsync(int clientId)
    {
        var recipes = new List<RecipeModel>();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from recipe where client_id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = clientId}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var recipe = new RecipeModel();

                recipe.Id = reader.GetInt32(reader.GetOrdinal("id"));
                recipe.ClientId = reader.GetInt32(reader.GetOrdinal("client_id"));
                recipe.TypeId = reader.GetInt32(reader.GetOrdinal("type_id"));
                recipe.Header = reader.GetString(reader.GetOrdinal("header"));
                
                var imagePath = reader.GetValue(reader.GetOrdinal("image_path"));
                recipe.ImagePath = imagePath == DBNull.Value ? null : imagePath.ToString();

                var source = reader.GetValue(reader.GetOrdinal("source_url"));
                recipe.SourceUrl = source == DBNull.Value ? null : source.ToString();
                
                var description = reader.GetValue(reader.GetOrdinal("description"));
                recipe.Description = description == DBNull.Value ? null : description.ToString();
                
                recipe.Code = reader.GetString(reader.GetOrdinal("code"));
                
                recipes.Add(recipe);
            }

            return recipes;
        }
        catch
        {
            return new List<RecipeModel>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> AddRecipeAsync(RecipeModel recipe)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into recipe(client_id, type_id, header," +
                        " code, image_path, source_url, description)" +
                        " VALUES ($1, $2, $3, $4, $5, $6, $7)" +
                        " returning id";


            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipe.ClientId},
                    new NpgsqlParameter {Value = recipe.TypeId},
                    new NpgsqlParameter {Value = recipe.Header},
                    new NpgsqlParameter {Value = recipe.Code},
                    new NpgsqlParameter {Value = recipe.ImagePath == null ? DBNull.Value : recipe.ImagePath},
                    new NpgsqlParameter {Value = recipe.SourceUrl == null ? DBNull.Value : recipe.SourceUrl},
                    new NpgsqlParameter {Value = recipe.Description == null ? DBNull.Value : recipe.Description}
                }
            };
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                recipe.Id = reader.GetInt32(reader.GetOrdinal("id"));
            }

            return recipe.Id;
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

    public async Task<int> UpdateRecipeAsync(RecipeModel recipe)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update recipe set type_id = $2, header = $3, source_url = $4, description = $5 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipe.Id},
                    new NpgsqlParameter {Value = recipe.TypeId},
                    new NpgsqlParameter {Value = recipe.Header},
                    new NpgsqlParameter {Value = recipe.SourceUrl == null ? DBNull.Value : recipe.SourceUrl},
                    new NpgsqlParameter {Value = recipe.Description == null ? DBNull.Value : recipe.Description}
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

    public async Task<int> UpdateRecipeImageAsync(int id, string imagePath)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update recipe set image_path = $2 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = id},
                    new NpgsqlParameter {Value = imagePath},
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

    public async Task<int> DeleteRecipeAsync(int id)
    {
        return await DeleteAsync("recipe", "id", id);
    }

    public async Task<int> DeleteRecipeImageAsync(int id)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update recipe set image_path = $2 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = id},
                    new NpgsqlParameter {Value = DBNull.Value},
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