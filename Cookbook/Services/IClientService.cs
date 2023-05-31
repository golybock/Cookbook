using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Database;
using Cookbook.Settings;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.Services;

public interface IClientService
{
    public static abstract bool IsAuth();

    public Client? GetCurrent();

    public Task<Client> Login(string login, string password);

    public void UnLogin();

    public Task<Client> Update(Client client, string? image);

    public Task<Client> Registration(Client client, string image);
}