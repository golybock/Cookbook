using ClientDatabase = Models.Database.Client.Client;

using CookbookApi.Repositories.Interfaces.Client;
using Models.Database.Client;
using Npgsql;

namespace CookbookApi.Repositories.Client;

public class ClientRoleRepository : RepositoryBase, IClientRoleRepository
{
    private readonly string _id = "id";
    private readonly string _name = "name";
    private string CurrentTable => TableNames.ClientRole;

    public ClientRoleRepository(IConfiguration configuration) 
        : base(configuration) { }
    
    public async Task<ClientRole?> GetAsync(int id)
    {
        var con = GetConnection();
    
        try
        {
            con.Open();
    
            var query = $"select * from {CurrentTable} where id = $1";
    
            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };
    
            await using var reader = await cmd.ExecuteReaderAsync();
    
            while (await reader.ReadAsync())
            {
                var clientRole = new ClientRole();
                
                clientRole.Id = reader.GetInt32(reader.GetOrdinal(_id));
                clientRole.Name = reader.GetString(reader.GetOrdinal(_name));
            
                return clientRole;
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

    public async Task<List<ClientRole>> GetAsync()
    {
        var con = GetConnection();

        List<ClientRole> clientRoles = new List<ClientRole>();

        try
        {
            con.Open();
    
            var query = $"select * from {CurrentTable}";

            await using var cmd = new NpgsqlCommand(query, con);

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var clientRole = new ClientRole();
                
                clientRole.Id = reader.GetInt32(reader.GetOrdinal(_id));
                clientRole.Name = reader.GetString(reader.GetOrdinal(_name));

                clientRoles.Add(clientRole);
            }
    
            return clientRoles;
        }
        catch (Exception e)
        {
            return clientRoles;
        }
        finally
        {
            await con.CloseAsync();
        }
    }
}