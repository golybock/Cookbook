using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Cookbook.Command;
using Cookbook.Database;
using Cookbook.Pages.Recipe;
using Cookbook.Services;
using Cookbook.ViewModel.Navigation;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.EntityFrameworkCore;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Recipe;

public class RecipeViewModel : ViewModelBase, INavItem
{
    private RecipeService _recipeService = new RecipeService();
    private ClientService _clientService = new ClientService();

    private bool _canEdit = false;
    private Database.Recipe? _recipe;

    private int _recipeId;
    private SeriesCollection _series = new SeriesCollection();
    private AxesCollection _axis = new AxesCollection();

    public INavHost Host { get; set; }

    public Database.Recipe? Recipe
    {
        get => _recipe;
        set
        {
            if (Equals(value, _recipe)) return;
            _recipe = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(RecipeIngredientsVisible));
            OnPropertyChanged(nameof(RecipeCategoriesVisible));
            OnPropertyChanged(nameof(RecipeStepsVisible));
        }
    }

    public RecipeViewModel(INavHost host, Database.Recipe recipe)
    {
        Host = host;
        _recipeId = recipe.Id;

        LoadAccess();
        LoadRecipe();
    }

    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 135")]
    [SuppressMessage("ReSharper.DPA", "DPA0007: Large number of DB records", MessageId = "count: 342")]
    private async void LoadRecipe()
    {
        Recipe = await _recipeService.Get(_recipeId);

        CanEdit = Recipe.ClientId == _clientService.GetCurrent()?.Id;
        
        LoadViews();
    }

    public SeriesCollection Series
    {
        get => _series;
        set
        {
            if (Equals(value, _series)) return;
            _series = value;
            OnPropertyChanged();
        }
    }

    public AxesCollection Axis
    {
        get => _axis;
        set
        {
            if (Equals(value, _axis)) return;
            _axis = value;
            OnPropertyChanged();
        }
    }

    private void LoadViews()
    {
        var viewGroups = Recipe.RecipeViews.GroupBy(c => c.Datetime.Day).ToList();

        ChartValues<int> views = new ChartValues<int>();

        AxesCollection axisList = new AxesCollection();
        List<string> labels = new List<string>();

        foreach (var view in viewGroups)
        {
            views.Add(view.Count());
            labels.Add(view.Key.ToString());
        }

        axisList.Add(new Axis(){ Labels = labels});
        
        Series = new SeriesCollection()
        {
            new LineSeries()
            {
                Values = views,
                Title = "Просмотров: ",
                Stroke = new SolidColorBrush(Colors.SlateBlue),
            },
        };

        Axis = axisList;
        
        OnPropertyChanged("Series");
    }

    public bool RecipeIngredientsVisible =>
        Recipe is {RecipeIngredients.Count: > 0};

    public bool RecipeCategoriesVisible =>
        Recipe is {RecipeCategories.Count: > 0};

    public bool RecipeStepsVisible =>
        Recipe is {RecipeSteps.Count: > 0};

    public bool RecipeStepsNotVisible =>
        !RecipeStepsVisible;

    public bool RecipeCategoriesNotVisible =>
        !RecipeCategoriesVisible;

    public bool RecipeIngredientsNotVisible =>
        !RecipeIngredientsVisible;

    public CommandHandler EditCommand =>
        new CommandHandler(Edit);

    public CommandHandler SaveCommand =>
        new CommandHandler(Save);

    public CommandHandler DeleteCommand =>
        new CommandHandler(Delete);

    public CommandHandler LikeCommand =>
        new CommandHandler(Like);

    private async void LoadAccess()
    {
        CanEdit = false;

        try
        {
            // if (client?.Login != null)
            //     if (client?.Login == Recipe.ClientOwner)
            //         CanEdit = true;
        }
        catch (Exception e)
        {
            CanEdit = false;
        }
    }

    public bool CanEdit
    {
        get => _canEdit;
        set
        {
            if (value == _canEdit) return;
            _canEdit = value;
            OnPropertyChanged();
        }
    }

    private async void Delete()
    {
        try
        {
            var recipe = await App.Context.Recipes.FirstOrDefaultAsync(c => c.Id == Recipe.Id);

            if (recipe != null)
            {
                App.Context.Recipes.Remove(recipe);
                await App.Context.SaveChangesAsync();
            }

            var notify = new ContentDialog()
            {
                Title = "Удалено",
                Content = "Рецепт успешно удален!",
                CloseButtonText = "Закрыть"
            };

            await notify.ShowAsync();

            Host.NavController.GoBack();
        }
        catch (Exception e)
        {
            var notify = new ContentDialog()
            {
                Title = "Ошибка",
                Content = "Возникла ошибка при удалении",
                CloseButtonText = "Закрыть"
            };

            await notify.ShowAsync();
        }
    }

    private async void Like()
    {
        var id = _clientService.GetCurrent()?.Id;

        await App.Context.FavoriteRecipes.AddAsync(new FavoriteRecipe() {ClientId = id, RecipeId = _recipeId});
    }

    private void Edit() =>
        Host.NavController.Navigate(new EditRecipePage(Host, Recipe));

    private async void Save()
    {

    }
}