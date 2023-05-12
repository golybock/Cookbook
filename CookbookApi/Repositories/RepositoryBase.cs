using Npgsql;

namespace CookbookApi.Repositories;

public abstract class RepositoryBase
{
    private readonly string _connectionString;

    protected RepositoryBase(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("cookbook_db")!;
    }

    protected NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }

    private string ConnectionString => _connectionString;

    protected async Task<int> DeleteAsync(string table, string row, object value)
    {
        var connection = GetConnection();

        try
        {
            connection.Open();

            var query = $"delete from {table} where {row} = $1";
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