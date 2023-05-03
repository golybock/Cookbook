using System.Diagnostics;
using Cookbook.Command;
using Cookbook.Settings;

namespace Cookbook.ViewModel.Settings;

public class SettingsViewModel : ViewModelBase
{
    public AppSettings? AppSettings { get; set; } = App.Settings;

    public CommandHandler OpenGitHubCommand =>
        new CommandHandler(OpenGitHub);

    private async void OpenGitHub()
    {
        if (AppSettings?.Github != null)
            Process.Start(new ProcessStartInfo() {FileName = AppSettings.Github, UseShellExecute = true});
    }
}