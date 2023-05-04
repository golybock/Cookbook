using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Cookbook.Pages.Client;

namespace Cookbook.ViewModel.Navigation;

public interface INavHost
{
    int CurrentPageIndex { get; set; }

    List<Page> Items { get; set; }

    Page? CurrentPage
    {
        get => Items.ElementAt(CurrentPageIndex);
        set
        {
            if (value != null)
                Items.Add(value);

            CurrentPageIndex = Items.Count - 1;
        }
    }

    void Navigate(Page page) => CurrentPage = page;

    void GoBack()
    {
        if (CurrentPageIndex == 0)
            return;

        CurrentPage = Items.Count > 1 ? Items.ElementAt(CurrentPageIndex - 1) : null;
    }

    void GoNext()
    {
        if (CurrentPage != null)
            CurrentPage = CurrentPageIndex + 1 < Items.Count - 1
                ? Items.ElementAt(CurrentPageIndex + 1)
                : Items.ElementAt(CurrentPageIndex);
    }
}