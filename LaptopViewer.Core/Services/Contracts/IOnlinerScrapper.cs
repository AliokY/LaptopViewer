using LaptopViewer.Domain;

namespace LaptopViewer.Core.Services.Contracts;

public interface IOnlinerScrapper
{
    /// <summary>
    /// Loads laptop data asynchronously from onliner API. Gets paginated data of <paramref name="page"/>
    /// </summary>
    /// <param name="page">The page number to load</param>
    /// <returns>An instance of OnlinerResponse if successful, otherwise - null</returns>
    Task<OnlinerResponse?> LoadLaptopsAsync(int page = 1);
}