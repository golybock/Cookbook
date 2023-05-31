using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cookbook.Views.Recipe;

public partial class RecipeCardView
{
    public RecipeCardView()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty ClickCommandProperty =
        DependencyProperty.Register(
            nameof(ClickCommand),
            typeof(ICommand),
            typeof(UserControl));


    public ICommand ClickCommand
    {
        get => (ICommand) GetValue(ClickCommandProperty);
        set => SetValue(ClickCommandProperty, value);
    }

    private void RecipeCard_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        ClickCommand.Execute(DataContext);
    }
}