using System;
using System.Collections.Generic;
using System.Windows;
using Cookbook.Command;
using Cookbook.Models.Domain.Recipe;
using Cookbook.Models.Domain.Recipe.Category;
using Cookbook.Models.Domain.Recipe.Ingredient;
using Cookbook.Pages.Recipe;
using Cookbook.ViewModel.Navigation;

namespace Cookbook.ViewModel.Recipe;

public class RecipeViewModel : ViewModelBase, INavItem
{
    public RecipeViewModel(INavHost host)
    {
        Host = host;
    }

    public RecipeViewModel(INavHost host, RecipeDomain recipe)
    {
        Host = host;
        Recipe = recipe;
    }
    
    public INavHost Host { get; set; }

    public RecipeDomain Recipe { get; set; } = new RecipeDomain();

    public CommandHandler EditCommand =>
        new CommandHandler(Edit);

    public CommandHandler SaveCommand =>
        new CommandHandler(Save);

    public CommandHandler DeleteCommand =>
        new CommandHandler(Delete);

    private void Delete()
    {
        
    }

    private void Edit()
    {
        Host.NavController.Navigate(new EditRecipePage(Host, Recipe));
    }

    private void Save()
    {
        MessageBox.Show("Сохранено");
    }
}