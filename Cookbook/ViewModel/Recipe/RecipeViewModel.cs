using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Media;
using Cookbook.Command;
using Cookbook.Database;
using Cookbook.FileGenerating;
using Cookbook.Pages.Recipe;
using Cookbook.Services;
using Cookbook.ViewModel.Navigation;
using LiveCharts;
using LiveCharts.Wpf;
using ModernWpf.Controls;

namespace Cookbook.ViewModel.Recipe;

public class RecipeViewModel : ViewModelBase, INavItem
{
    public RecipeViewModel(INavHost host, Database.Recipe recipe)
    {
        Host = host;
        _recipe = recipe;

        LoadRecipe();
    }

    # region services

    private readonly RecipeService _recipeService = new();
    private readonly ClientService _clientService = new();

    #endregion

    #region private members

    private bool _canEdit;
    private Database.Recipe _recipe;

    private SeriesCollection _series = new();
    private AxesCollection _axis = new();

    #endregion

    #region public members

    public INavHost Host { get; set; }

    #region bind models

    public Database.Recipe Recipe
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

    #endregion

    #endregion

    #region get and render data

    private async void LoadRecipe()
    {
        Recipe = (await _recipeService.Get(Recipe.Id))!;

        CanEdit = Recipe.ClientId == _clientService.GetCurrent()?.Id;

        LoadViews();
    }

    private void LoadViews()
    {
        var viewGroups = Recipe
            .RecipeViews
            .GroupBy(c => new {c.Datetime.Day, c.Datetime.Month})
            .ToList();

        var views = new ChartValues<int>();

        var axisList = new AxesCollection();
        List<string> labels = new();

        foreach (var view in viewGroups)
        {
            views.Add(view.Count());
            labels.Add(view.Key.Day + " " + GetMontName(view.Key.Month));
        }

        axisList.Add(new Axis() {Labels = labels});
        Axis = axisList;

        Series = new SeriesCollection()
        {
            new LineSeries()
            {
                Values = views,
                Title = "Просмотров: ",
                Stroke = new SolidColorBrush(Colors.SlateBlue)
            }
        };
    }

    #endregion

    #region private functions

    private string GetMontName(int month)
    {
        return new DateTime(2000, month, 1)
            .ToString("MMM", CultureInfo.CreateSpecificCulture("ru"));
    }

    private async void Like()
    {
        var id = _clientService.GetCurrent()?.Id;

        var fav = App.Context.FavoriteRecipes.FirstOrDefault(c => c.ClientId == id && c.RecipeId == Recipe.Id);

        if (fav == null)
        {
            await App.Context.FavoriteRecipes.AddAsync(new FavoriteRecipe() {ClientId = id, RecipeId = Recipe.Id});
            await App.Context.SaveChangesAsync();

            var notify = new ContentDialog()
            {
                Title = "Сохранено",
                Content = "Рецепт добавлен в избранное",
                CloseButtonText = "Закрыть"
            };

            await notify.ShowAsync();
        }
        else
        {
            App.Context.FavoriteRecipes.Remove(fav);
            await App.Context.SaveChangesAsync();

            var notify = new ContentDialog()
            {
                Title = "Сохранено",
                Content = "Рецепт удален из избранного",
                CloseButtonText = "Закрыть"
            };

            await notify.ShowAsync();
        }
    }

    private void Edit()
    {
        Host.NavController.Navigate(new EditRecipePage(Host, Recipe));
    }

    private void Save()
    {
        RecipeDocX.Generate(Recipe);
    }

    private async void Delete()
    {
        try
        {
            await _recipeService.Delete(Recipe);

            var notify = new ContentDialog()
            {
                Title = "Удалено",
                Content = "Рецепт успешно удален!",
                CloseButtonText = "Закрыть"
            };

            await notify.ShowAsync();

            Host.NavController.GoBack();
        }
        catch
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

    #endregion

    #region bind render values

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

    #endregion

    #region commands

    public CommandHandler EditCommand => new(Edit);

    public CommandHandler SaveCommand => new(Save);

    public CommandHandler DeleteCommand => new(Delete);

    public CommandHandler LikeCommand => new(Like);

    #endregion
}