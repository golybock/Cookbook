using System;
using System.Threading.Tasks;
using Cookbook.Command;
using Cookbook.Pages.Client;
using Cookbook.Services;
using Cookbook.ViewModel.Navigation;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Auth;

public class LoginViewModel : ViewModelBase, INavItem
{
    private string _error = string.Empty;

    private string _password = string.Empty;

    private string _login = string.Empty;

    private ClientService _clientService = new();

    public INavHost Host { get; set; }

    public LoginViewModel(INavHost host)
    {
        Host = host;
    }

    public string Login
    {
        get => _login;
        set
        {
            if (value == _login) return;
            _login = value;
            OnPropertyChanged();
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            if (value == _password) return;
            _password = value;
            OnPropertyChanged();
        }
    }

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

    public CommandHandler LoginCommand => new(LoginAsync);

    public CommandHandler CancelCommand => new(CanselAsync);

    private async void LoginAsync()
    {
        try
        {
            await _clientService.Login(Login, Password);

            Host.NavController.Navigate(new ClientPage(Host));
        }
        catch (Exception e)
        {
            Error = e.Message;
        }
    }

    private async void CanselAsync()
    {
        var cancel = new ContentDialog()
        {
            Title = "Отмена авторизации",
            Content = "Вы хотите отменить авторизацию?",
            CloseButtonText = "Остаться",
            PrimaryButtonText = "Отменить"
        };

        var result = await cancel.ShowAsync();

        if (result == ContentDialogResult.Primary)
            Host.NavController.GoBack();
    }
}