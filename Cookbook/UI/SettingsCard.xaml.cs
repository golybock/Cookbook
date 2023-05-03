using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Cookbook.UI;

[ContentProperty("Content")]
public partial class SettingsCard : UserControl
{
    public SettingsCard()
    {
        InitializeComponent();
        DataContext = this;
    }

    #region InnerContent

    public new FrameworkElement Content
    {
        get => (FrameworkElement)GetValue(ContentProperty);
        set
        {
            SetValue(ContentProperty, value);
            ContentControl.Content = value;
            ArrayForwardVisibility = Visibility.Collapsed;
        }
    }

    // Using a DependencyProperty as the backing store for InnerContent.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(
            nameof(Content),
            typeof(FrameworkElement),
            typeof(SettingsCard),
            new UIPropertyMetadata(null));

    #endregion

    public static readonly DependencyProperty HeaderProperty =
        DependencyProperty.Register(
            nameof(Header),
            typeof(string),
            typeof(SettingsCard));

    public static readonly DependencyProperty DescriptionProperty =
        DependencyProperty.Register(
            nameof(Description),
            typeof(string),
            typeof(SettingsCard));

    public static readonly DependencyProperty ImageSourceProperty =
        DependencyProperty.Register(
            nameof(ImageSource),
            typeof(ImageSource),
            typeof(SettingsCard));
    
    public static readonly DependencyProperty ArrayForwardVisibilityProperty =
        DependencyProperty.Register(
            nameof(ArrayForwardVisibility),
            typeof(Visibility),
            typeof(SettingsCard));
    
    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set
        {
            SetValue(HeaderProperty, value);
            HeaderTextBlock.Text = HeaderProperty.ToString();
        }
    }

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set
        {
            SetValue(HeaderProperty, value);
            DescriptionTextBlock.Text = DescriptionProperty.ToString();
        }
    }

    public ImageSource ImageSource
    {
        get => (ImageSource)GetValue(ImageSourceProperty);
        set
        {
            SetValue(ImageSourceProperty, value);
            Icon.Source = value;
        }
    }

    public Visibility ArrayForwardVisibility
    {
        get => (Visibility)GetValue(ArrayForwardVisibilityProperty);
        set
        {
            SetValue(ArrayForwardVisibilityProperty, value);
            ArrayForward.Visibility = value;
            ContentControl.Visibility = InvertVisibility(value);
        }
    }

    private Visibility InvertVisibility(Visibility visibility) =>
        visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
}