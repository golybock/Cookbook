using Cookbook.Command;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.ViewModel.Client;

public class EditClientVIewModel : ViewModelBase, INavigationItem
{
    public EditClientVIewModel(INavHost host)
    {
        Host = host;
    }

    public INavHost Host { get; set; }

    // public CommandHandler CancelCommand =>
    //     new CommandHandler();
    //
    // public CommandHandler SaveCommand =>
    //     new CommandHandler();
}