using System.Collections.ObjectModel;
using Cookbook.Models.Domain.Recipe;

namespace Cookbook.ViewModel.Recipe;

public class RecipeListViewModel : ViewModelBase
{
    public ObservableCollection<RecipeDomain> Recipes { get; set; } = new ObservableCollection<RecipeDomain>();


    public RecipeListViewModel()
    {
        Recipes.Add(new RecipeDomain() { Header = "Beba"});
        Recipes.Add(new RecipeDomain() { Header = "Boba"});
        Recipes.Add(new RecipeDomain() { Header = "Biba"});
        Recipes.Add(new RecipeDomain() { Header = "Biba"});
        Recipes.Add(new RecipeDomain() { Header = "Biba"});
        Recipes.Add(new RecipeDomain() { Header = "Biba"});
        Recipes.Add(new RecipeDomain() { Header = "Biba"});
        OnPropertyChanged("Recipes");
    }
}