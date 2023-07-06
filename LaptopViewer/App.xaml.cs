using LaptopViewer.Core.Services;
using LaptopViewer.Core.Services.Contracts;
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
        Container = ConfigureDependencyInjection();
    }

    public IServiceProvider Container { get; }

    static IServiceProvider ConfigureDependencyInjection()
    {
        //Create anew service collection which generates the IServiceProvider
        ServiceCollection serviceCollection = new();

        serviceCollection.AddSingleton<IOnlinerScrapper, OnlinerScrapper>();

        //Build the IServiceProvider and return it
        return serviceCollection.BuildServiceProvider();
    }
}
