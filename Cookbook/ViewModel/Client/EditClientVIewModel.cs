using Cookbook.Command;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.ViewModel.Client;

public class EditClientVIewModel : ViewModelBase, INavItem
{
    public EditClientVIewModel(INavHost host)
    {
        Host = host;
    }

    public INavHost Host { get; set; }

    public CommandHandler CancelCommand =>
        new CommandHandler(CancelEdit);
    
    // public CommandHandler SaveCommand =>
    //     new CommandHandler();

    private void CancelEdit()
    {
        Host.NavController.GoBack();
    }
}