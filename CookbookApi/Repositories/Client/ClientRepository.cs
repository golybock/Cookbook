using CookbookApi.Repositories.Interfaces.Client;
using Npgsql;
using ClientDatabase = Models.Database.Client.Client;

namespace CookbookApi.Repositories.Client;

public class ClientRepository : RepositoryBase, IClientRepository
{
    private readonly string _id = "id";
    private readonly string _roleId = "role_id";
    private readonly string _login = "login";
    private readonly string _passwordHash = "password_hash";
    private readonly string _description = "description";
    private readonly string _name = "name";
    private readonly string _email = "email";
    private readonly string _imagePath = "image_path";

    public ClientRepository(IConfiguration configuration)
        : base(configuration) { }
    
    public async Task<ClientDatabase?> GetAsync(int id)
    {
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
                var client = new ClientDatabase();
                
                client.Id = reader.GetInt32(reader.GetOrdinal(_id));

                client.RoleId = reader.GetInt32(reader.GetOrdinal(_roleId));
                
                var login = reader.GetValue(reader.GetOrdinal(_login));
                client.Login = login == DBNull.Value ? null : login.ToString();

                var password = reader.GetValue(reader.GetOrdinal(_passwordHash));
                client.PasswordHash = password == DBNull.Value ? null : password.ToString();

                var name = reader.GetValue(reader.GetOrdinal(_name));
                client.Name = name == DBNull.Value ? null : name.ToString();

                var description = reader.GetValue(reader.GetOrdinal(_description));
                client.Description = description == DBNull.Value ? null : description.ToString();

                var email = reader.GetValue(reader.GetOrdinal(_email));
                client.Email = email == DBNull.Value ? null : email.ToString();

                var image = reader.GetValue(reader.GetOrdinal(_imagePath));
                client.ImagePath = image == DBNull.Value ? null : image.ToString();

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

    public async Task<ClientDatabase?> GetAsync(string login)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from client where login = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = login}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var client = new ClientDatabase();
                
                client.Id = reader.GetInt32(reader.GetOrdinal(_id));

                client.RoleId = reader.GetInt32(reader.GetOrdinal(_roleId));

                client.Login = login;

                var password = reader.GetValue(reader.GetOrdinal(_passwordHash));
                client.PasswordHash = password == DBNull.Value ? null : password.ToString();

                var name = reader.GetValue(reader.GetOrdinal(_name));
                client.Name = name == DBNull.Value ? null : name.ToString();

                var description = reader.GetValue(reader.GetOrdinal(_description));
                client.Description = description == DBNull.Value ? null : description.ToString();

                var email = reader.GetValue(reader.GetOrdinal(_email));
                client.Email = email == DBNull.Value ? null : email.ToString();

                var image = reader.GetValue(reader.GetOrdinal(_imagePath));
                client.ImagePath = image == DBNull.Value ? null : image.ToString();


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

    public async Task<int> AddAsync(ClientDatabase client)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into client(login, password_hash, name, description, email, role_id)" +
                        " values ($1, $2, $3, $4, $5, $6) returning id";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = client.Login == null ? DBNull.Value : client.Login},
                    new NpgsqlParameter {Value = client.PasswordHash == null ? DBNull.Value : client.PasswordHash},
                    new NpgsqlParameter {Value = client.Name == null ? DBNull.Value : client.Name},
                    new NpgsqlParameter {Value = client.Description == null ? DBNull.Value : client.Description},
                    new NpgsqlParameter {Value = client.Email == null ? DBNull.Value : client.Email},
                    new NpgsqlParameter {Value = client.RoleId <= 0 ? 2 : client.RoleId }
                }
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
                client.Id = reader.GetInt32(reader.GetOrdinal(_id));

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

    public async Task<int> UpdateAsync(int id, ClientDatabase client)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = $"update client" +
                        $" set login = $2, password_hash = $3, name = $4, description = $5, email = $6" +
                        $" where {_id} = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = id},
                    new NpgsqlParameter {Value = client.Login == null ? DBNull.Value : client.Login},
                    new NpgsqlParameter {Value = client.PasswordHash == null ? DBNull.Value : client.PasswordHash},
                    new NpgsqlParameter {Value = client.Name == null ? DBNull.Value : client.Name},
                    new NpgsqlParameter {Value = client.Description == null ? DBNull.Value : client.Description},
                    new NpgsqlParameter {Value = client.Email == null ? DBNull.Value : client.Email},
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

    public async Task<int> UpdateImageAsync(int id, string? image)
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
                    new NpgsqlParameter {Value = image == null ? DBNull.Value : image},
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

    public async Task<int> UpdatePasswordAsync(int id, string passwordHash)
    {
        var con = GetConnection();

        try
        {
            con.Open();

            var query = "update client set password_hash = $2 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = id},
                    new NpgsqlParameter {Value = passwordHash},
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

    public async Task<int> DeleteAsync(int id) =>
        await DeleteAsync("client", "id", id);

    public Task<int> DeleteClientImageAsync(int id) =>
        UpdateImageAsync(id, null);
}