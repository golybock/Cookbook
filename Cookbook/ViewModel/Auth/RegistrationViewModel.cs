using Cookbook.Command;

namespace Cookbook.ViewModel.Auth;

public class RegistrationViewModel : ViewModelBase
{
    private string _error;

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
        Error = "Беба";
    }
}