using LaptopViewer.Core.Mvvm;
using LaptopViewer.Core.Services.Contracts;
using LaptopViewer.Domain;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace LaptopViewer.Wpf.ViewModels;

public class MainViewModel : ViewModelBase
{
    #region Fields

    private readonly IOnlinerScrapper _onlinerScrapper;

    #endregion

    public MainViewModel(IOnlinerScrapper onlinerScrapper)
    {
        _onlinerScrapper = onlinerScrapper;

        LoadDataCommand = new RelayCommand(OnLoadDataAsync);
    }

    #region Commands

    public ICommand LoadDataCommand { get; }

    public ObservableCollection<ProductResponse> Laptops { get; set; } = new ObservableCollection<ProductResponse>();

    #endregion

    #region Properties

    public string Title { get; set; } = "My test app";

    #endregion


    #region Methods


    private async void OnLoadDataAsync(object? obj)
    {
        _ = Application.Current.Dispatcher.BeginInvoke(() => { Laptops.Clear(); });

        var laptops = await _onlinerScrapper.LoadLaptopsAsync().ConfigureAwait(false);

        if (laptops is null)
        {
            return;
        }
    
        foreach( var item in laptops.Products)
        {
            _ = Application.Current.Dispatcher.BeginInvoke(() =>
            {
                Laptops.Add(item);
            });
        }
    }

    #endregion
}
