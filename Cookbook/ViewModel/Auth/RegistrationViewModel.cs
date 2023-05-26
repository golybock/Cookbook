using System;
using System.Windows.Controls;
using Cookbook.Command;
using Cookbook.Pages.Client;
using Cookbook.ViewModel.Navigation;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Auth;

public class RegistrationViewModel : ViewModelBase, INavItem
{

    public INavHost Host { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    public RegistrationViewModel(INavHost host)
    {
        Host = host;
    }

    private string _error = string.Empty;

    public string Error
    {
        get => _error;
        set
        {
            if (value == _error) return;
            _error = value;
            OnPropertyChanged();
        }
    }

    public CommandHandler RegistrationCommand =>
        new CommandHandler(Registration);
    
    public CommandHandler CancelCommand =>
        new CommandHandler(CanselAsync);
    
    private async void Registration()
    {
        throw new NotImplementedException();
    }

    private async void CanselAsync()
    {
        var cancel = new ContentDialog()
        {
            Title = "Отмена",
            Content = "Вы хотите отменить регистрацию?",
            CloseButtonText = "Остаться",
            PrimaryButtonText = "Отменить"
        };

        var result = await cancel.ShowAsync();

        if (result == ContentDialogResult.Primary)
            Host.NavController.GoBack();
    }
}