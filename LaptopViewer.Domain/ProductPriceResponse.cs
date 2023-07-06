using Newtonsoft.Json;

namespace LaptopViewer.Domain;

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
