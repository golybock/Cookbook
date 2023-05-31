using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Cookbook.UI;

[ContentProperty("Content")]
public partial class ContentCard : UserControl
{
    public ContentCard()
    {
        InitializeComponent();
    }

    public new static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(
            nameof(Content),
            typeof(FrameworkElement),
            typeof(ContentCard),
            new UIPropertyMetadata(null));

    public new FrameworkElement Content
    {
        get => (FrameworkElement) GetValue(ContentProperty);
        set
        {
            SetValue(ContentProperty, value);
            ContentControl.Content = value;
        }
    }

    private void ContentControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        ContentControl.Content = Content;
    }
}