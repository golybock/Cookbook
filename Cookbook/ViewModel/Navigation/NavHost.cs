using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Cookbook.ViewModel.Navigation;

public class NavHost
{
    public NavHost(Page currentPage)
    {
        _currentPage = currentPage;
    }

    private Page? _currentPage;

    private List<Page> Items { get; set; } = new List<Page>();

    public Page? CurrentPage
    {
        get => Items.LastOrDefault();
        set
        {
            if (value != null) 
                Items.Add(value);
        }
    }

    public void Navigate(Page page) => CurrentPage = page;

    public void GoBack() =>
        CurrentPage = Items.Count > 1 ? Items.ElementAt(Items.Count - 2) : null;

    public void GoNext()
    {
        if (_currentPage != null)
        {
            var current = Items.IndexOf(_currentPage);

            CurrentPage = current + 1 < Items.Count ? Items.ElementAt(current + 1) : Items.ElementAt(current);
        }
    }
    
}