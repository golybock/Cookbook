using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;


namespace Cookbook.UI;

[ContentProperty("Content")]
public partial class SettingsCard : UserControl
{
    public SettingsCard()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty ClickCommandProperty =
        DependencyProperty.Register(
            nameof(ClickCommand),
            typeof(ICommand),
            typeof(SettingsCard));

    public new static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(
            nameof(Content),
            typeof(FrameworkElement),
            typeof(SettingsCard),
            new UIPropertyMetadata(null));

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

    public ICommand? ClickCommand
    {
        get => (ICommand)GetValue(ClickCommandProperty);
        set => SetValue(ClickCommandProperty, value);
    }
    
    public new FrameworkElement Content
    {
        get => (FrameworkElement)GetValue(ContentProperty);
        set
        {
            SetValue(ContentProperty, value);
            ContentControl.Content = value;
        }
    }
    
    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set
        {
            SetValue(HeaderProperty, value);
            HeaderTextBlock.Text = value;
        }
    }

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set
        {
            SetValue(HeaderProperty, value);
            DescriptionTextBlock.Text = value;
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

    private void HeaderTextBlock_OnLoaded(object sender, RoutedEventArgs e)
    {
        HeaderTextBlock.Text = Header;
    }

    private void DescriptionTextBlock_OnLoaded(object sender, RoutedEventArgs e)
    {
        DescriptionTextBlock.Text = Description;
    }

    private void ArrayForward_OnLoaded(object sender, RoutedEventArgs e)
    {
        ArrayForward.Visibility = ArrayForwardVisibility;
    }

    private void ContentControl_OnLoaded(object sender, RoutedEventArgs e)
    {
        ContentControl.Content = Content;
    }

    private void Icon_OnLoaded(object sender, RoutedEventArgs e)
    {
        Icon.Source = ImageSource;
    }

    private void SettingsCard_OnLoaded(object sender, RoutedEventArgs e)
    {
        this.MouseDown += delegate(object o, MouseButtonEventArgs args)
        {
            if (ClickCommand != null) 
                ClickCommand.Execute(null);
        };
    }
}