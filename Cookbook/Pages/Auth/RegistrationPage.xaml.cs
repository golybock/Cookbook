using System.Windows.Controls;
using Cookbook.ViewModel.Auth;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.Pages.Auth;

public partial class RegistrationPage : Page
{
    public RegistrationPage(INavHost host)
    {
        InitializeComponent();
        DataContext = new RegistrationViewModel(host);
    }
}