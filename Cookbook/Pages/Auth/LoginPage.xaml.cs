using System.Windows.Controls;
using Cookbook.ViewModel.Auth;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.Pages.Auth;

public partial class LoginPage : Page
{
    public LoginPage(INavHost host)
    {
        InitializeComponent();
        DataContext = new LoginViewModel(host);
    }
}