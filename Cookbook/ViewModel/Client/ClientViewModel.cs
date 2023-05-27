using Cookbook.Command;
using Cookbook.Pages.Auth;
using Cookbook.Pages.Client;
using Cookbook.Services;
using Cookbook.ViewModel.Navigation;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Client;

public class ClientViewModel : ViewModelBase, INavItem
{
    private readonly ClientService _clientService = new ClientService();

    public string? Image => Client.ImagePath;
    
    public INavHost Host { get; set; }

    private Database.Client _client = new Database.Client(); 
    
    public CommandHandler EditCommand =>
        new CommandHandler(Edit);
    
    public CommandHandler UnLoginCommand =>
        new CommandHandler(UnLogin);
    
    public ClientViewModel(INavHost host)
    {
        Client = _clientService.GetCurrent();
        Host = host;
    }
    
    private void Edit()
    {
        Host.NavController.Navigate(new EditClientPage(Host, Client));
    }
    
    private async void UnLogin()
    {
        var cancel = new ContentDialog()
        {
            Title = "Выход из акаунта",
            Content = "Вы хотите выйти из акаунта?",
            CloseButtonText = "Остаться",
            PrimaryButtonText = "Выйти"
        };

        var result = await cancel.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            _clientService.UnLogin();
            Host.NavController.Navigate(new NoAuthPage(Host));    
        }
    }
    
    public Database.Client Client
    {
        get => _client;
        set
        {
            if (Equals(value, _client)) return;
            _client = value;
            OnPropertyChanged();
        }
    }
}