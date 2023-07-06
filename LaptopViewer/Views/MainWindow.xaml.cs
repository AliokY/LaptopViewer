using LaptopViewer.Wpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LaptopViewer.Wpf.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // Get a local instance of the container
        var container = ((App)Application.Current).Container;

        DataContext = ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(MainViewModel));
    }
}
