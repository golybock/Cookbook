using Blank.Client;
using Domain.Client;

namespace Builders.Blank.Client;

public class ClientBlankBuilder
{
    public ClientBlank Create(Database.Client.Client clientDatabase)
    {
        var client = new ClientBlank();
        
        client.Login = clientDatabase.Login;
        client.Name = clientDatabase.Name;
        client.Email = clientDatabase.Email;
        client.Description = clientDatabase.Description;

        return client;
    }

    public ClientBlank Create(ClientDomain clientDomain)
    {
        var client = new ClientBlank();
        
        client.Login = clientDomain.Login;
        client.Name = clientDomain.Name;
        client.Email = clientDomain.Email;
        client.Description = clientDomain.Description;

        return client;
    }
}