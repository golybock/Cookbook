using Cookbook.Command;
using Cookbook.Pages.Auth;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.ViewModel.Auth;

public class NoAuthViewModel : ViewModelBase, INavItem
{
    public INavHost Host { get; set; }
    
    public NoAuthViewModel(INavHost host) => Host = host;

    public CommandHandler LoginCommand =>
        new CommandHandler(Login);

    public CommandHandler RegistrationCommand =>
        new CommandHandler(Registration);
    
    private void Login() =>
        Host.NavController.Navigate(new LoginPage(Host));

    private void Registration() =>
        Host.NavController.Navigate(new RegistrationPage(Host));
}