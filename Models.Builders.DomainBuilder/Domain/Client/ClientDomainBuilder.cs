using Models.Blank.Client;
using Models.Domain.Client;

namespace Models.Builders.DomainBuilder.Domain.Client;

public static class ClientDomainBuilder
{
    public static ClientDomain Create(ClientBlank clientBlank)
    {
        var blank = new ClientDomain();
        
        blank.Name = clientBlank.Name;
        blank.Email = clientBlank.Email;
        blank.Description = clientBlank.Description;

        return blank;
    }

    public static ClientDomain Create(Database.Client.Client client)
    {
        var blank = new ClientDomain();
        
        blank.Name = client.Name;
        blank.Email = client.Email;
        blank.Description = client.Description;

        return blank;
    }

    public static ClientDomain Create(string name, string email, string description)
    {
        var blank = new ClientDomain();
        
        blank.Name = name;
        blank.Email = email;
        blank.Description = description;

        return blank;   
    }
}