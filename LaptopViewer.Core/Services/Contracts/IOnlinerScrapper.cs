using LaptopViewer.Domain;

namespace LaptopViewer.Core.Services.Contracts;

public interface IOnlinerScrapper
{
    /// <summary>
    /// Loads laptop data asynchronously from website
    /// </summary>
    /// <param name="page">The page number to load</param>
    /// <returns>An instance of OnlinerResponse if successful, or null if otherwise</returns>
    Task<OnlinerResponse?> LoadLaptopsAsync(int page = 1);
}