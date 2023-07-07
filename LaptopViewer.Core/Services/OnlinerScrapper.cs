using LaptopViewer.Core.Models;
using LaptopViewer.Core.Services.Contracts;
using LaptopViewer.Domain;

namespace LaptopViewer.Core.Services;

/// <summary>
/// Service for scraping laptop data from onliner API
/// </summary>
public class OnlinerScrapper : DataServiceBase, IOnlinerScrapper
{
    private const string LaptopsUri = @"https://catalog.onliner.by/sdapi/catalog.api/search/notebook?page={0}";

    /// <inheritdoc />
    public async Task<OnlinerResponse?> LoadLaptopsAsync(int page = 1)
    {
        ApiResponse<OnlinerResponse> response = await GetAsync<OnlinerResponse>(new Uri(string.Format(LaptopsUri, page)), CancellationToken.None);

        if (response.Success)
        {
            return response.Result;
        }
        else
        {
            return null;
        }
    }
}
