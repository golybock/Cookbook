using System;
using System.Windows.Controls;
using Cookbook.Command;
using Cookbook.Pages.Client;
using Cookbook.Services;
using Cookbook.ViewModel.Navigation;
using Microsoft.Win32;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Auth;

public class RegistrationViewModel : ViewModelBase, INavItem
{
    private readonly ClientService _clientService = new ClientService();
    public INavHost Host { get; set; }

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Image
    {
        get => _image;
        set
        {
            if (value == _image) return;
            _image = value;
            OnPropertyChanged();
        }
    }

    public RegistrationViewModel(INavHost host)
    {
        Host = host;
    }

    private string _error = string.Empty;
    private string? _image;

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

    public CommandHandler ChooseImageCommand =>
        new CommandHandler(ChooseImage);
    
    public CommandHandler CancelCommand =>
        new CommandHandler(CancelAsync);
    
    private async void Registration()
    {
        try
        {
            var client = new Database.Client() {Name = Name, Email = Email, Password = Password};
            
            await _clientService.Registration(client, Image);
            
            Host.NavController.Navigate(new ClientPage(Host));
        }
        catch (Exception e)
        {
            Error = e.Message;
        }
    }

    private async void ChooseImage()
    {
        var path = ChooseFile();
        
        if(path == null)
            return;

        Image = path;
    }
    
    private string? ChooseFile()
    {
        var openFileDialog = new OpenFileDialog
        {
            InitialDirectory = "C:\\",
            Filter = "Image files (*.png)|*.png|All files (*.*)|*.*"
        };
        
        if (openFileDialog.ShowDialog() == true)
            return openFileDialog.FileName;

        return null;
    }

    private async void CancelAsync()
    {
        var cancel = new ContentDialog()
        {
            Title = "Подтверждение",
            Content = "Вы хотите отменить регистрацию?",
            CloseButtonText = "Остаться",
            PrimaryButtonText = "Отменить"
        };

        var result = await cancel.ShowAsync();

        if (result == ContentDialogResult.Primary)
            Host.NavController.GoBack();
    }
}