using LaptopViewer.Core.Models;
using LaptopViewer.Core.Services.Contracts;
using LaptopViewer.Domain;

namespace LaptopViewer.Core.Services;

public class OnlinerScrapper : DataServiceBase, IOnlinerScrapper
{
    private const string LaptopsUri = "https://catalog.onliner.by/sdapi/catalog.api/search/notebook";

    public async Task<OnlinerResponse?> LoadLaptopsAsync()
    {
        ApiResponse<OnlinerResponse> response = await GetAsync<OnlinerResponse>(new Uri(LaptopsUri), CancellationToken.None);

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
