using Cookbook.Command;
using Cookbook.Pages.Client;
using Cookbook.Services;
using Cookbook.ViewModel.Navigation;
using Microsoft.Win32;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Client;

public class EditClientVIewModel : ViewModelBase, INavItem
{
    public EditClientVIewModel(INavHost host, Database.Client client)
    {
        Host = host;
        Image = client.ImagePath;
        Client = client;
    }

    #region private members

    private readonly ClientService _clientService = new();
    private string? _image;

    #endregion

    #region bind members

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

    #endregion

    #region public members

    public INavHost Host { get; set; }

    #endregion

    #region command handlers

    public CommandHandler CancelCommand => new(CancelEdit);

    public CommandHandler SaveCommand => new(Save);

    public CommandHandler ChooseImageCommand => new(ChooseImage);

    #endregion

    #region private functions

    private void ChooseImage()
    {
        var path = ChooseFile();

        if (path == null)
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

        if (result == ContentDialogResult.Primary) Host.NavController.GoBack();
    }

    private async void Save()
    {
        await _clientService.Update(Client, Image);

        Host.NavController.Navigate(new ClientPage(Host));
    }

    #endregion
}