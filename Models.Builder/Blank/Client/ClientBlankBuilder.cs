using Models.Blank.Client;
using Models.Domain.Client;

namespace Models.Builder.Blank.Client;

public class ClientBlankBuilder
{
    public static ClientBlank Create(ClientDomain clientDomain)
    {
        var blank = new ClientBlank();
        
        blank.Name = clientDomain.Name;
        blank.Email = clientDomain.Email;
        blank.Description = clientDomain.Description;

        return blank;
    }

    public static ClientBlank Create(Database.Client.Client client)
    {
        var blank = new ClientBlank();
        
        blank.Name = client.Name;
        blank.Email = client.Email;
        blank.Description = client.Description;

        return blank;
    }

    public static ClientBlank Create(string name, string email, string description)
    {
        var blank = new ClientBlank();
        
        blank.Name = name;
        blank.Email = email;
        blank.Description = description;

        return blank;   
    }
}