using LaptopViewer.Wpf.ViewModels;
using System.Windows;

namespace LaptopViewer.Wpf.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(MainViewModel mainViewModel)
    {
        InitializeComponent();

        DataContext = mainViewModel;
    }
}
