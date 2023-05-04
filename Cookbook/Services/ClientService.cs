using System;
using System.Net.Http;
using System.Threading.Tasks;
using Cookbook.Api.Client;
using Cookbook.Models.Domain.Client;
using Cookbook.Settings;

namespace Cookbook.Services;

public class ClientService
{
    private readonly ClientApi _clientApi = new ClientApi();
    private AppSettings _appSettings = App.Settings!;

    public async Task<ClientDomain?> GetClientDomain()
    {
        return await _clientApi.GetClientAsync();
    }
}