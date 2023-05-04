using System.Windows.Controls;
using Cookbook.ViewModel.Client;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.Pages.Client;

public partial class ClientPage : Page
{
    public ClientPage(INavHost host)
    {
        InitializeComponent();
        ClientView.DataContext = new ClientViewModel(host);
    }
}