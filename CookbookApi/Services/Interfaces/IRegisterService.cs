using ClientModel = CookbookApi.Models.Database.Client.Client;

namespace CookbookApi.Services.Interfaces;

public interface IRegisterService
{
    public PasswordResult PasswordValidate(string pass);
    public Task<RegisterResult> Register(ClientModel client);
}