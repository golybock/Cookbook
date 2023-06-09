﻿using System;
using System.Threading.Tasks;
using System.Windows;
using Cookbook.Models.Database;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Cookbook.Database.Repositories;

public class RepositoryBase
{
    private string? _connectionString;

    public RepositoryBase()
    {
        GetConnectionString();
    }

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }

    private void GetConnectionString() =>
        _connectionString = "host=127.0.0.1;port=5432;Username=admin;Password=admin;Database=Cookbook;";

    public bool TrustConnection()
    {
        var connection = GetConnection();

        try
        {
            connection.Open();
            return true;
        }
        catch
        {
            MessageBox.Show("Не удалось подключиться к базе");
            return false;
        }
        finally
        {
            connection.Close();
        }
    }

    protected async Task<CommandResult> DeleteAsync(string table, int id)
    {
        CommandResult result;

        var connection = GetConnection();

        try
        {
            connection.Open();

            var query = $"delete from {table} where id = $1";
            await using var cmd = new NpgsqlCommand(query, connection)
            {
                Parameters =
                {
                    new NpgsqlParameter {Value = id}
                }
            };

            result = await cmd.ExecuteNonQueryAsync() > 0 ? CommandResults.Successfully : CommandResults.NotFulfilled;

            return result;
        }
        catch (Exception e)
        {
            result = CommandResults.BadRequest;
            result.Description = e.ToString();

            return result;
        }
        finally
        {
            await connection.CloseAsync();
        }
    }
}