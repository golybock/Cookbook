using CookbookApi.Repositories.Interfaces.ClientInterfaces;
using Npgsql;
using ClientModel = CookbookApi.Models.Database.Client.Client;

namespace CookbookApi.Repositories.Client;

public class ClientRepository : RepositoryBase, IClientRepository
{
    public async Task<ClientModel> GetClientAsync(int id)
    {
        var client = new ClientModel();

        var con = GetConnection();
        try
        {
            con.Open();

            var query = "select * from client where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                client.Id = reader.GetInt32(reader.GetOrdinal("id"));
                client.Login = reader.GetString(reader.GetOrdinal("login"));
                client.Password = reader.GetString(reader.GetOrdinal("password"));
                var name = reader.GetValue(reader.GetOrdinal("name"));
                client.Name = name == DBNull.Value ? null : name.ToString();
                var description = reader.GetValue(reader.GetOrdinal("description"));
                client.Description = description == DBNull.Value ? null : description.ToString();
            }

            return client;
        }
        catch
        {
            return new ClientModel();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> AddClient(ClientModel client)
    {
        int result;

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into client(login, password, name)" +
                        " values ($1, $2, $3) returning id";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = client.Login},
                    new NpgsqlParameter {Value = client.Password},
                    new NpgsqlParameter {Value = client.Name == null ? DBNull.Value : client.Name}
                }
            };

            await using var reader = await cmd.ExecuteReaderAsync();
            
            while (await reader.ReadAsync())
            {
                client.Id = reader.GetInt32(reader.GetOrdinal("id"));
            }

            return client.Id;
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

    public async Task<int> UpdateClientAsync(int id, ClientModel client)
    {
        int result;

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update client set name = $2, description = $3 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = client.Id},
                    new NpgsqlParameter {Value = client.Name == null ? DBNull.Value : client.Name},
                    new NpgsqlParameter {Value = client.Description == null ? DBNull.Value : client.Description}
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

    public async Task<ClientModel> GetClientAsync(string login)
    {
        var client = new ClientModel();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from client where login = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = login == string.Empty ? DBNull.Value : login}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                client.Id = reader.GetInt32(reader.GetOrdinal("id"));
                client.Login = reader.GetString(reader.GetOrdinal("login"));
                client.Password = reader.GetString(reader.GetOrdinal("password"));
                var name = reader.GetValue(reader.GetOrdinal("name"));
                client.Name = name == DBNull.Value ? null : name.ToString();
                var description = reader.GetValue(reader.GetOrdinal("description"));
                client.Description = description == DBNull.Value ? null : description.ToString();
            }

            return client;
        }
        catch (Exception e)
        {
            return new ClientModel();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<List<ClientModel>> GetClientsAsync()
    {
        var clients = new List<ClientModel>();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from client";

            await using var cmd = new NpgsqlCommand(query, con);

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var client = new ClientModel();

                client.Id = reader.GetInt32(reader.GetOrdinal("id"));
                client.Login = reader.GetString(reader.GetOrdinal("login"));
                client.Password = reader.GetString(reader.GetOrdinal("password"));
                var name = reader.GetValue(reader.GetOrdinal("name"));
                client.Name = name == DBNull.Value ? null : name.ToString();
                var description = reader.GetValue(reader.GetOrdinal("description"));
                client.Description = description == DBNull.Value ? null : description.ToString();

                clients.Add(client);
            }

            return clients;
        }
        catch
        {
            return new List<ClientModel>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }
    
    public async Task<int> DeleteClientAsync(int id)
    {
        int result;

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "delete from client where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
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
            await con.CloseAsync();
        }
    }
}