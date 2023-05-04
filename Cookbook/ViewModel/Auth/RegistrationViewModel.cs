using System.Windows.Controls;
using Cookbook.Command;
using Cookbook.Pages.Client;
using Cookbook.ViewModel.Navigation;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Auth;

public class RegistrationViewModel : ViewModelBase
{
    public NavigationViewModel Parent { get; set; }
    
    public ContentDialog? View { get; set; }
    
    public RegistrationViewModel(NavigationViewModel parent)
    {
        Parent = parent;
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

    private async void Registration()
    {
        Parent.CurrentPage = new ClientPage();
        
        View?.Hide();
    }
}