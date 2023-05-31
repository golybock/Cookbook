using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Cookbook.ViewModel.Navigation;

public class NavController : ViewModelBase
{
    public NavController(Page currentPage)
    {
        CurrentPage = currentPage;
    }

    public NavController()
    {
    }

    private int _currentPageIndex = 0;

    private List<Page> Items { get; set; } = new();

    public Page? CurrentPage
    {
        get
        {
            try
            {
                return Items.ElementAt(_currentPageIndex);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        private set
        {
            if (value != null)
                Items.Add(value);

            _currentPageIndex = Items.Count - 1;

            OnPropertyChanged();
        }
    }

    public void Navigate(Page page)
    {
        CurrentPage = page;
    }

    public void GoBack()
    {
        CurrentPage = _currentPageIndex > 1 ? Items.ElementAt(_currentPageIndex - 1) : null;
    }

    public void GoNext()
    {
        if (Items.Count - 1 > _currentPageIndex)
            CurrentPage = Items.ElementAt(_currentPageIndex + 1);
    }

    public void Clear()
    {
        Items = new List<Page>();
        CurrentPage = null;
        _currentPageIndex = 0;
    }
}