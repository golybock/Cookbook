using Models.Blank.Client;
using Models.Domain.Client;
using ClientDatabase = Models.Database.Client.Client;

namespace Models.Builders.DatabaseBuilder.Database.Client;

public static class ClientDatabaseBuilder
{
    public static ClientDatabase Create(ClientDomain clientDomain)
    {
        var database = new ClientDatabase();
        
        database.Name = clientDomain.Name;
        database.Login = clientDomain.Login;
        database.Email = clientDomain.Email;
        database.Description = clientDomain.Description;
        database.ImagePath = clientDomain.ImagePath;

        return database;
    }

    public static ClientDatabase Create(ClientBlank clientBlank)
    {
        var database = new ClientDatabase();
        
        database.Name = clientBlank.Name;
        database.Email = clientBlank.Email;
        database.Description = clientBlank.Description;

        return database;
    }
}