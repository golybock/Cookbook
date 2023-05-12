
using Models.Blank.Client;
using Models.Domain.Client;

namespace Models.Builders.DomainBuilder.Domain.Client;

public static class ClientDomainBuilder
{
    public static ClientDomain Create(ClientBlank clientBlank)
    {
        var domain = new ClientDomain();
        
        domain.Name = clientBlank.Name;
        domain.Email = clientBlank.Email;
        domain.Description = clientBlank.Description;

        return domain;
    }

    public static ClientDomain Create(Database.Client.Client client)
    {
        var domain = new ClientDomain();
        
        domain.Name = client.Name;
        domain.Email = client.Email;
        domain.Description = client.Description;

        return domain;
    }

    public static ClientDomain Create(string name, string email, string description)
    {
        var domain = new ClientDomain();
        
        domain.Name = name;
        domain.Email = email;
        domain.Description = description;

        return domain;   
    }
}