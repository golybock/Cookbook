using System.Threading.Tasks;
using CookbookApi.Models.Register;
using CookbookApi.Models.Register.Password;
using ClientModel = CookbookApi.Models.Database.Client.Client;

namespace Cookbook.Database.Services.Interfaces;

public interface IRegisterService
{
    public PasswordResult PasswordValidate(string pass);
    public Task<RegisterResult> Register(ClientModel client);
}