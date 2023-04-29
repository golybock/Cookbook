using CookbookApi.Models.Database.Client;
using CookbookApi.Repositories.Interfaces.ClientInterfaces;
using Npgsql;

namespace CookbookApi.Repositories.Client;

public class ClientFavRepository : RepositoryBase, IClientFavoriteRepository
{
    public async Task<int> AddFavoriteRecipeAsync(FavoriteRecipe favoriteRecipe)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into favorite_recipes(recipe_id, client_id)" +
                        " values ($1, $2) returning id";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = favoriteRecipe.RecipeId},
                    new NpgsqlParameter {Value = favoriteRecipe.ClientId}
                }
            };
            
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync()) favoriteRecipe.Id = reader.GetInt32(reader.GetOrdinal("id"));

            return favoriteRecipe.Id;
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

    public Task<int> DeleteFavoriteRecipeAsync(int id)
    {
        return DeleteAsync("favorite_recipes", "id", id);
    }

    public async Task<int> DeleteFavoriteRecipeAsync(int recipeId, int clientId)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "delete from favorite_recipes where recipe_id = $1 and client_id = $2";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = recipeId},
                    new NpgsqlParameter {Value = clientId}
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

    public async Task<int> DeleteRecipeFromFavoritesAsync(int recipeId)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "delete from favorite_recipes where recipe_id = $1";

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

    public async Task<int> DeleteClientFavoriteRecipes(int clientId)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "delete from favorite_recipes where client_id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = clientId}
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

    public async Task<FavoriteRecipe?> GetFavoriteRecipeAsync(int id)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from favorite_recipes where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var favoriteRecipe = new FavoriteRecipe();
                favoriteRecipe.Id = reader.GetInt32(reader.GetOrdinal("id"));
                favoriteRecipe.ClientId = reader.GetInt32(reader.GetOrdinal("client_id"));
                favoriteRecipe.RecipeId = reader.GetInt32(reader.GetOrdinal("recipe_id"));
                return favoriteRecipe;
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

    public async Task<List<FavoriteRecipe>> GetFavoriteRecipesAsync(int clientId)
    {
        var favoriteRecipes = new List<FavoriteRecipe>();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from favorite_recipes where client_id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = clientId}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var favoriteRecipe = new FavoriteRecipe();

                favoriteRecipe.Id = reader.GetInt32(reader.GetOrdinal("id"));
                favoriteRecipe.ClientId = reader.GetInt32(reader.GetOrdinal("client_id"));
                favoriteRecipe.RecipeId = reader.GetInt32(reader.GetOrdinal("recipe_id"));

                favoriteRecipes.Add(favoriteRecipe);
            }

            return favoriteRecipes;
        }
        catch
        {
            return new List<FavoriteRecipe>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }
}