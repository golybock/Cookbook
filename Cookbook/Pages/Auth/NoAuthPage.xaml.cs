using System.Windows.Controls;
using Cookbook.ViewModel.Auth;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.Pages.Auth;

public partial class NoAuthPage : Page
{
    public NoAuthPage(INavHost host)
    {
        InitializeComponent();
        NoAuthView.DataContext = new NoAuthViewModel(host);
    }
}