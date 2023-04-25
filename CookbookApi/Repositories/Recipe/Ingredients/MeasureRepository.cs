using CookbookApi.Models.Database.Recipe.Ingredient;
using CookbookApi.Repositories.Interfaces.RecipeInterfaces.IngredientsInterfaces;
using Npgsql;

namespace CookbookApi.Repositories.Recipe.Ingredients;

public class MeasureRepository : RepositoryBase, IMeasureRepository
{
    public async Task<Measure> GetMeasureAsync(int id)
    {
        var measure = new Measure();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from measure where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters = {new NpgsqlParameter {Value = id}}
            };

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                measure.Id = reader.GetInt32(reader.GetOrdinal("id"));
                measure.Name = reader.GetString(reader.GetOrdinal("name"));
            }

            return measure;
        }
        catch
        {
            return new Measure();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<List<Measure>> GetMeasuresAsync()
    {
        var measures = new List<Measure>();

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "select * from measure";

            await using var cmd = new NpgsqlCommand(query, con);

            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var measure = new Measure();
                measure.Id = reader.GetInt32(reader.GetOrdinal("id"));
                measure.Name = reader.GetString(reader.GetOrdinal("name"));
                measures.Add(measure);
            }

            return measures;
        }
        catch
        {
            return new List<Measure>();
        }
        finally
        {
            await con.CloseAsync();
        }
    }

    public async Task<int> AddMeasureAsync(Measure measure)
    {
        int result;

        var con = GetConnection();

        try
        {
            con.Open();

            var query = "insert into measure(name) values ($1) returning id";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = measure.Id},
                    new NpgsqlParameter {Value = measure.Name}
                }
            };
            
            await using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync()) measure.Id = reader.GetInt32(reader.GetOrdinal("id"));

            return measure.Id;
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

    public async Task<int> UpdateMeasureAsync(Measure measure)
    {
        var con = GetConnection();

        try
        {
            await con.OpenAsync();

            var query = "update measure set name = $2 where id = $1";

            await using var cmd = new NpgsqlCommand(query, con)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = measure.Id},
                    new NpgsqlParameter {Value = measure.Name}
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

    public async Task<int> DeleteMeasureAsync(int id)
    {
        return await DeleteAsync("measure", "id", id.ToString());
    }
}