using LaptopViewer.Core.Services;
using LaptopViewer.Core.Services.Contracts;
using LaptopViewer.Wpf.ViewModels;
using LaptopViewer.Wpf.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace LaptopViewer.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        Container = RegisterServices();

        MainWindow = Container.GetService<MainWindow>();
        MainWindow?.Show();
    }

    public IServiceProvider Container { get; private set; }

    private IServiceProvider RegisterServices()
    {
        // Create a new service collection which generates the IServiceProvider
        ServiceCollection serviceCollection = new();

        serviceCollection.AddSingleton<IOnlinerScrapper, OnlinerScrapper>();
        serviceCollection.AddSingleton<MainViewModel>();
        serviceCollection.AddSingleton<MainWindow>((svc) => new Views.MainWindow(Container.GetService<MainViewModel>()));

        // Build the IServiceProvider and return it
        return serviceCollection.BuildServiceProvider();
    }

    private void Application_Startup(object sender, StartupEventArgs e)
    {

    }
}
