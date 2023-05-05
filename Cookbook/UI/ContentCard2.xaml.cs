using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Cookbook.UI;

[ContentProperty("Content2")]
public partial class ContentCard2 : UserControl
{
    public ContentCard2()
    {
        InitializeComponent();
    }

    public new static readonly DependencyProperty Content2Property =
        DependencyProperty.Register(
            nameof(Content2),
            typeof(FrameworkElement),
            typeof(ContentCard),
            new UIPropertyMetadata(null));
    
    public new FrameworkElement Content2
    {
        get => (FrameworkElement)GetValue(Content2Property);
        set
        {
            SetValue(Content2Property, value);
            ContentControl.Content = value;
        }
    }
    
    private void ContentControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        ContentControl.Content = Content2;
    }
}