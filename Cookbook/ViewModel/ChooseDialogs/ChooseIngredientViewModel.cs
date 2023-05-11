using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Cookbook.Models.Blank.Recipe;
using Cookbook.Models.Domain.Recipe;
using Cookbook.Models.Domain.Recipe.Ingredient;
using Cookbook.Services;

namespace Cookbook.ViewModel.ChooseDialogs;

public class ChooseIngredientViewModel : ViewModelBase
{
    public ChooseIngredientViewModel()
    {
        GetIngredients();
        RecipeIngredientDomain.Count = _count;
    }

    private readonly RecipeService _recipeService = new RecipeService();
    
    private IngredientDomain _selectedIngredient = new IngredientDomain();
    
    private int _count = 1;

    public IngredientDomain SelectedIngredient
    {
        get => _selectedIngredient;
        set
        {
            if (Equals(value, _selectedIngredient)) return;
            _selectedIngredient = value;

            RecipeIngredientDomain.Ingredient = value;

            OnPropertyChanged();
        }
    }

    public ObservableCollection<IngredientDomain> Ingredients { get; set; } =
        new ObservableCollection<IngredientDomain>();

    public int Count
    {
        get => _count;
        set
        {
            _count = value;
            RecipeIngredientDomain.Count = _count;
        }
    }

    public async void GetIngredients()
    {
        var ingredients = await _recipeService.Ingredient.Get();

        if (ingredients != null) 
            Ingredients = new(ingredients);

        SelectedIngredient = Ingredients.LastOrDefault()!;
    }

    public RecipeIngredientDomain RecipeIngredientDomain { get; set; } = new RecipeIngredientDomain();
}