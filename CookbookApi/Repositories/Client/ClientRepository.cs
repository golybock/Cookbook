using CookbookApi.Repositories.Interfaces.ClientInterfaces;
using Npgsql;
using ClientModel = CookbookApi.Models.Database.Client.Client;

namespace CookbookApi.Repositories.Client;

public class ClientRepository : RepositoryBase, IClientRepository
{
    public async Task<ClientModel?> GetClientAsync(string token)
    {
        var con = GetConnection();
        
        try
        {
            con.Open();

            var query = "select * from client where token = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = token}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var client = new ClientModel();
                client.Id = reader.GetInt32(reader.GetOrdinal("id"));
                
                var login = reader.GetValue(reader.GetOrdinal("login"));
                client.Login = login == DBNull.Value ? null : login.ToString();
                
                var password = reader.GetValue(reader.GetOrdinal("password"));
                client.Password = password == DBNull.Value ? null : password.ToString();
                
                var name = reader.GetValue(reader.GetOrdinal("name"));
                client.Name = name == DBNull.Value ? null : name.ToString();
                
                var description = reader.GetValue(reader.GetOrdinal("description"));
                client.Description = description == DBNull.Value ? null : description.ToString();
                
                var email = reader.GetValue(reader.GetOrdinal("email"));
                client.Email = email == DBNull.Value ? null : email.ToString();

                client.Token = reader.GetString(reader.GetOrdinal("token"));
                
                return client;
            }

            return null;
        }
        catch(Exception e)
        {
            return null;
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> AddClient(ClientModel client)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into client(login, password, name, token, email)" +
                        " values ($1, $2, $3, $4, $5) returning id";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = client.Login == null ? DBNull.Value : client.Login},
                    new NpgsqlParameter {Value = client.Password == null ? DBNull.Value : client.Password},
                    new NpgsqlParameter {Value = client.Name == null ? DBNull.Value : client.Name},
                    new NpgsqlParameter { Value = client.Token},
                    new NpgsqlParameter { Value = client.Email == null ? DBNull.Value : client.Email}
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
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update client set name = $2, description = $3, email = $4 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = client.Id},
                    new NpgsqlParameter {Value = client.Name == null ? DBNull.Value : client.Name},
                    new NpgsqlParameter {Value = client.Description == null ? DBNull.Value : client.Description},
                    new NpgsqlParameter { Value = client.Email == null ? DBNull.Value : client.Email}
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

    public async Task<int> UpdateToken(int id, string token)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update client set token = $2 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = id},
                    new NpgsqlParameter {Value = token},
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

    public async Task<int> UpdateImage(int id, string image)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update client set image_path = $2 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = id},
                    new NpgsqlParameter {Value = image},
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

    public async Task<int> UpdatePassword(int id, string password)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update client set password = $2 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = id},
                    new NpgsqlParameter {Value = password},
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

    public async Task<ClientModel?> GetClientByLoginAsync(string login)
    {
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
                var client = new ClientModel();
                client.Id = reader.GetInt32(reader.GetOrdinal("id"));

                client.Login = login;
                
                var password = reader.GetValue(reader.GetOrdinal("password"));
                client.Password = password == DBNull.Value ? null : password.ToString();
                
                var name = reader.GetValue(reader.GetOrdinal("name"));
                client.Name = name == DBNull.Value ? null : name.ToString();
                
                var description = reader.GetValue(reader.GetOrdinal("description"));
                client.Description = description == DBNull.Value ? null : description.ToString();
                
                var email = reader.GetValue(reader.GetOrdinal("email"));
                client.Email = email == DBNull.Value ? null : email.ToString();

                client.Token = reader.GetString(reader.GetOrdinal("token"));
                
                return client;
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
                
                var login = reader.GetValue(reader.GetOrdinal("login"));
                client.Login = login == DBNull.Value ? null : login.ToString();
                
                var password = reader.GetValue(reader.GetOrdinal("password"));
                client.Password = password == DBNull.Value ? null : password.ToString();
                
                var name = reader.GetValue(reader.GetOrdinal("name"));
                client.Name = name == DBNull.Value ? null : name.ToString();
                
                var description = reader.GetValue(reader.GetOrdinal("description"));
                client.Description = description == DBNull.Value ? null : description.ToString();
                
                var email = reader.GetValue(reader.GetOrdinal("email"));
                client.Email = email == DBNull.Value ? null : email.ToString();

                client.Token = reader.GetString(reader.GetOrdinal("token"));

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