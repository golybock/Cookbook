using System.Threading.Tasks;
using Cookbook.Command;
using Cookbook.Pages.Auth;
using Cookbook.Pages.Client;
using Cookbook.Services;
using Cookbook.ViewModel.Navigation;
using Microsoft.Win32;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Client;

public class EditClientVIewModel : ViewModelBase, INavItem
{
    private readonly ClientService _clientService = new ClientService();
    private string? _image;

    public Database.Client Client { get; set; }

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

    public EditClientVIewModel(INavHost host, Database.Client client)
    {
        Host = host;
        Image = client.ImagePath;
        Client = client;
    }

    public INavHost Host { get; set; }

    public CommandHandler CancelCommand =>
        new CommandHandler(CancelEdit);
    
    public CommandHandler SaveCommand =>
        new CommandHandler(Save);

    
    public CommandHandler ChooseImageCommand =>
        new CommandHandler(ChooseImage);

    private void ChooseImage()
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
    
    private async void CancelEdit()
    {
        var cancel = new ContentDialog()
        {
            Title = "Отмена редактирования",
            Content = "Отменить редактирование профиля?",
            CloseButtonText = "Остаться",
            PrimaryButtonText = "Отменить"
        };

        var result = await cancel.ShowAsync();

        if (result == ContentDialogResult.Primary)
        {
            Host.NavController.GoBack();    
        }
        
    }

    private async void Save()
    {
        await _clientService.Update(Client, Image);

        Host.NavController.Navigate(new ClientPage(Host));    
    }
}