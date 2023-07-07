using Newtonsoft.Json;

namespace LaptopViewer.Domain;

/// <summary>
/// Gets or sets the minimum price of the product
/// </summary>
public class ProductPriceResponse
{
    [JsonProperty("price_min")]
    public Price? MinPrice { get; set; }

    public class Price
    {
        [JsonProperty("amount")] 
        public string Amount { get; set; } = "0";
    }
}
