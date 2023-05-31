using System.Windows;
using System.Windows.Controls;

namespace Cookbook.Views.Auth;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        ((dynamic) DataContext).Password = ((PasswordBox) sender).Password;
    }
}