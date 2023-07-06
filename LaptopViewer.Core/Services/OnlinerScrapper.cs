using LaptopViewer.Core.Models;
using LaptopViewer.Core.Services.Contracts;
using LaptopViewer.Domain;

namespace LaptopViewer.Core.Services;

public class OnlinerScrapper : DataServiceBase, IOnlinerScrapper
{
    private const string LaptopsUri = @"https://catalog.onliner.by/sdapi/catalog.api/search/notebook?page={0}";

    public async Task<OnlinerResponse?> LoadLaptopsAsync(int page = 1)
    {
        ApiResponse<OnlinerResponse> response = await GetAsync<OnlinerResponse>(new Uri(string.Format(LaptopsUri, page)), CancellationToken.None);

        if (response.Success)
        {
            return response.Result;
        }
        else
        {
            // throw exception?
            return null;
        }
    }
}
