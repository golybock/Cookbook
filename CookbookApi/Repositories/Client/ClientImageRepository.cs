using CookbookApi.Models.Database.Client;
using CookbookApi.Repositories.Interfaces.ClientInterfaces;
using Npgsql;

namespace CookbookApi.Repositories.Client;

public class ClientImageRepository : RepositoryBase, IClientImageRepository
{
    public async Task<ClientImage> GetClientImageAsync(int id)
    {
        var clientImage = new ClientImage();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from client_images where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                clientImage.Id = reader.GetInt32(reader.GetOrdinal("id"));
                clientImage.ClientId = reader.GetInt32(reader.GetOrdinal("client_id"));
                clientImage.Path = reader.GetString(reader.GetOrdinal("path"));
            }

            return clientImage;
        }
        catch
        {
            return new ClientImage();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<List<ClientImage>> GetClientImagesAsync(int clientId)
    {
        var clientImages = new List<ClientImage>();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from client_images where client_id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = clientId}}
            };
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var clientImage = new ClientImage();
                clientImage.Id = reader.GetInt32(reader.GetOrdinal("id"));
                clientImage.ClientId = reader.GetInt32(reader.GetOrdinal("client_id"));
                clientImage.Path = reader.GetString(reader.GetOrdinal("path"));
                clientImages.Add(clientImage);
            }

            return clientImages;
        }
        catch
        {
            return new List<ClientImage>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<List<ClientImage>> GetClientImagesAsync(int clientId, int limit)
    {
        throw new NotImplementedException();
    }

    public async Task<int> AddClientImageAsync(ClientImage clientImage)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into client_images(client_id, path)" +
                        " values ($1, $2) returning id";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = clientImage.ClientId},
                    new NpgsqlParameter {Value = clientImage.Path}
                }
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                clientImage.Id = reader.GetInt32(reader.GetOrdinal("id"));
            }

            return clientImage.Id;
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

    public async Task<int> UpdateClientImageAsync(ClientImage clientImage)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update client_images set path = $2 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = clientImage.Id},
                    new NpgsqlParameter {Value = clientImage.Path}
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

    public async Task<int> DeleteClientImageAsync(int id)
    {
        return await DeleteAsync("client_images", "id", id.ToString());
    }

}