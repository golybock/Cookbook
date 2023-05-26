using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Database;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.ViewModel.ChooseDialogs;

public class ChooseIngredientViewModel : ViewModelBase
{
    public ChooseIngredientViewModel()
    {
        GetIngredients();
        RecipeIngredient.Count = _count;
    }

    private Ingredient _selectedIngredient = new Ingredient();
    
    private int _count = 1;
    
    public Ingredient SelectedIngredient
    {
        get => _selectedIngredient;
        set
        {
            if (Equals(value, _selectedIngredient)) return;
            _selectedIngredient = value;
    
            RecipeIngredient.Ingredient = value;
    
            OnPropertyChanged();
        }
    }
    
    public ObservableCollection<Ingredient> Ingredients { get; set; } =
        new ObservableCollection<Ingredient>();
    
    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            RecipeIngredient.Count = _count;
        }
    }
    
    public async void GetIngredients()
    {
        var ingredients = await App.Context.Ingredients.ToListAsync();
        
        Ingredients = new(ingredients);
    
        SelectedIngredient = Ingredients.LastOrDefault()!;
    }
    
    public RecipeIngredient RecipeIngredient { get; set; } = new RecipeIngredient();
}