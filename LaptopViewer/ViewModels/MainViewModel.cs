using LaptopViewer.Core.Mvvm;
using LaptopViewer.Core.Services.Contracts;
using LaptopViewer.Domain;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LaptopViewer.Wpf.ViewModels;

public class MainViewModel : ViewModelBase
{
    #region Fields

    private readonly IOnlinerScrapper _onlinerScrapper;
    private int _currentPage = 1;
    private bool _isLoading;
    private bool _hasDataLoaded;

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

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            RaisePropertyChanged();
        }
    }

    public bool HasDataLoaded
    {
        get => _hasDataLoaded;
        set 
        {
            _hasDataLoaded = value;
            RaisePropertyChanged();
        }
    }

    #endregion

    #region Methods

    /// <summary>
    /// Asynchronously loads data based on the specified direction
    /// </summary>
    /// <param name="direction">The direction of data loading (NEXT or PREV)</param>
    private async void OnLoadDataAsync(object? direction)
    {
        IsLoading = true;

        try
        {
            int page = GetPage(direction);

            _ = Application.Current.Dispatcher.BeginInvoke(() => { Laptops.Clear(); });

            OnlinerResponse? laptops = await _onlinerScrapper.LoadLaptopsAsync(page).ConfigureAwait(false);
            HasDataLoaded = laptops != null && laptops.Products.Any();

            if (!HasDataLoaded)
            {
                return;
            }

            foreach (var item in laptops.Products)
            {
                _ = Application.Current.Dispatcher.BeginInvoke(() =>
                {
                    Laptops.Add(item);
                });
            }
        }
        finally
        {
            IsLoading = false;
        }
    }

    /// <summary>
    /// Gets the page number based on the specified direction
    /// </summary>
    /// <param name="direction">The direction of data loading (NEXT or PREV)</param>
    /// <returns>The page number</returns>
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
