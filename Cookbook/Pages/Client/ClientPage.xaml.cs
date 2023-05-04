using System.Windows.Controls;
using Cookbook.ViewModel.Client;

namespace Cookbook.Pages.Client;

public partial class ClientPage : Page
{
    public ClientPage()
    {
        InitializeComponent();
        ClientView.DataContext = new ClientViewModel();
    }
}