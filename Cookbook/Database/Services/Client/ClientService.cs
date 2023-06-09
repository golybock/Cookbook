﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Cookbook.Database.Repositories.Client;
using Cookbook.Database.Services.Interfaces.ClientInterfaces;
using Cookbook.Models.Database;
using Cookbook.Models.Database.Client;
using ClientModel = Cookbook.Models.Database.Client.Client;

namespace Cookbook.Database.Services.Client;

public class ClientService : IClientService
{
    private readonly ClientImageService _clientImageService;
    private readonly ClientRepository _clientRepository;

    public ClientService()
    {
        _clientRepository = new ClientRepository();
        _clientImageService = new ClientImageService();
    }

    public async Task<ClientModel> GetClientAsync(int id)
    {
        if (id <= 0)
            return new ClientModel();

        return await _clientRepository.GetClientAsync(id);
    }

    public async Task<ClientModel> GetClientAsync(string login)
    {
        if (string.IsNullOrEmpty(login))
            return new ClientModel();

        return await _clientRepository.GetClientAsync(login);
    }

    public async Task<List<ClientModel>> GetClientsAsync()
    {
        return await _clientRepository.GetClientsAsync();
    }

    public async Task<CommandResult> AddClientAsync(ClientModel client)
    {
        if (string.IsNullOrWhiteSpace(client.Login))
            return CommandResults.BadRequest;

        if (string.IsNullOrWhiteSpace(client.Password))
            return CommandResults.BadRequest;

        return await _clientRepository.AddClientAsync(client);
    }

    public async Task<CommandResult> UpdateClientAsync(ClientModel client)
    {
        if (client.Id <= 0)
            return CommandResults.BadRequest;

        var commandResult =
            await _clientRepository.UpdateClientAsync(client);

        if (commandResult.Result)
            if (client.NewImagePath != null)
            {
                // save image to docs
                var newClientImage =
                    new ClientImage
                    {
                        ClientId = client.Id,
                        ImagePath = client.NewImagePath
                    };

                client.ClientImage.ClientId = client.Id;
                client.ClientImage.ImagePath = CopyImageToDocuments(newClientImage);

                var cmdResult =
                    await _clientImageService.AddClientImageAsync(client.ClientImage);

                if (cmdResult.Result)
                    client.ClientImage = (cmdResult.Value as ClientImage)!;

                return CommandResults.Successfully;
            }

        return CommandResults.BadRequest;
    }

    public Task<CommandResult> DeleteClientAsync(int id)
    {
        throw new NotImplementedException();
    }

    private string? CopyImageToDocuments(ClientImage clientImage)
    {
        var documentsPath = $"C:\\Users\\{Environment.UserName}\\Documents\\Images\\Clients\\";

        var filePath = $"client_{clientImage.ClientId}_{App.GetTimeStamp()}.png";

        var writePath = documentsPath + filePath;

        if (File.Exists(clientImage.GetImagePath()))
        {
            File.Copy(clientImage.GetImagePath(), writePath);
            return filePath;
        }

        return null;
    }
}