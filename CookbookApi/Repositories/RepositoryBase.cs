using Npgsql;

namespace CookbookApi.Repositories;

public class RepositoryBase
{
    private readonly string _connectionString = "host=127.0.0.1;port=5432;Username=admin;Password=admin;DatabaseModels=cookbook;";

    protected NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }

    private string GetConnectionString() => _connectionString;

    public async Task<int> DeleteAsync(string table, string where, object value)
    {
        var connection = GetConnection();

        try
        {
            connection.Open();

            var query = $"delete from {table} where {where} = $1";
            await using var cmd = new NpgsqlCommand(query, connection)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = value}
                }
            };

            return await cmd.ExecuteNonQueryAsync();
        }
        catch (Exception e)
        {
            return 0;
        }
        finally
        {
            await connection.CloseAsync();
        }
    }
}