using LaptopViewer.Domain;

namespace LaptopViewer.Core.Services.Contracts;

public interface IOnlinerScrapper
{
    Task<OnlinerResponse?> LoadLaptopsAsync();
}
