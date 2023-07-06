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
    private int _currentPage = 1;

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

    public int CurrentPage
    {
        get => _currentPage;
        set
        {
            _currentPage = value;
            RaisePropertyChanged();
        }
    }

    #endregion


    #region Methods

    private async void OnLoadDataAsync(object? direction)
    {
        int page = GetPage(direction);

        _ = Application.Current.Dispatcher.BeginInvoke(() => { Laptops.Clear(); });

        var laptops = await _onlinerScrapper.LoadLaptopsAsync(page).ConfigureAwait(false);

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

    private int GetPage(object? direction)
    {
        if (direction as string is null)
            return CurrentPage;

        if (((string)direction).ToUpper().Equals("NEXT"))
            return ++CurrentPage;
        else if (CurrentPage != 1)
            return --CurrentPage;
        else 
            return CurrentPage;
    }

    #endregion
}
