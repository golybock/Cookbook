using Cookbook.Command;
using Cookbook.Views.Auth;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Auth;

public class NoAuthViewModel : ViewModelBase
{
    public CommandHandler AuthCommand =>
        new CommandHandler(ShowLoginDialog);

    public CommandHandler RegistrationCommand =>
        new CommandHandler(ShowRegistrationDialog);
    
    private async void ShowLoginDialog()
    {
        var context = new LoginViewModel();
        
        var loginDialog = new ContentDialog
        {
            Title = "Авторизация",
            Content = new LoginView(),
            DataContext = context,
            CloseButtonText = "Отмена"
        };

        await loginDialog.ShowAsync();
    }
    
    private async void ShowRegistrationDialog()
    {
        var context = new RegistrationViewModel();
        
        var registrationDialog = new ContentDialog
        {
            Title = "Регистрация",
            DataContext = context,
            Content = new RegistrationView(),
            CloseButtonText = "Отмена"
        };

        await registrationDialog.ShowAsync();
    }
}