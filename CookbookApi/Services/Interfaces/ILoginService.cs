namespace CookbookApi.Services.Interfaces;

public interface ILoginService
{
    public Task<LoginResult> Login(string login, string password);
}