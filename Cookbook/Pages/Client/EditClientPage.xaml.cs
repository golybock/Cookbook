using System.Windows.Controls;
using Cookbook.ViewModel.Client;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.Pages.Client;

public partial class EditClientPage : Page
{
    public EditClientPage(INavHost host, Database.Client client)
    {
        InitializeComponent();
        DataContext = new EditClientVIewModel(host, client);
    }
}