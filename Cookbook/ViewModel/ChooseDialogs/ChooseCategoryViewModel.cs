using System.Collections.ObjectModel;
using System.Linq;
using Cookbook.Database;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.ViewModel.ChooseDialogs;

public class ChooseCategoryViewModel : ViewModelBase
{
    public ChooseCategoryViewModel()
    {
        GetIngredients();
    }

    private Category _selectedCategory = new Category();

    public Category SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (Equals(value, _selectedCategory)) return;
            _selectedCategory = value;

            OnPropertyChanged();
        }
    }
    
    public ObservableCollection<Category> Categories { get; set; } =
        new ObservableCollection<Category>();
    
    public async void GetIngredients()
    {
        var categories = await App.Context.Categories.ToListAsync();
        
        Categories = new(categories);
    
        SelectedCategory = Categories.LastOrDefault()!;
    }
}