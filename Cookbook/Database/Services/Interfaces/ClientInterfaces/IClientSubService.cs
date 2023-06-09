﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Cookbook.Models.Database;
using Cookbook.Models.Database.Client;

namespace Cookbook.Database.Services.Interfaces.ClientInterfaces;

public interface IClientSubService
{
    public Task<ClientSub?> GetClientSubAsync(int id);
    public Task<ClientSub?> GetClientSubAsync(int clientId, int subId);
    public Task<List<ClientSub>> GetClientSubsAsync(int clientId);
    public Task<List<ClientSub>> GetSubsClientAsync(int clientId);
    public Task<bool> ClientIsLiked(int clientId, int subId);
    public Task<CommandResult> AddClientSubAsync(ClientSub clientSub);
    public Task<CommandResult> UpdateClientSubAsync(ClientSub clientSub);
    public Task<CommandResult> DeleteClientSubAsync(int id);
    public Task<CommandResult> DeleteClientSubAsync(int clientId, int id);
}