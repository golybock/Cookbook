using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Cookbook.Pages.Client;

namespace Cookbook.ViewModel.Navigation;

public interface INavHost
{
    public NavController NavController { get; set; }
}