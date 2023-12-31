﻿using Newtonsoft.Json;

namespace LaptopViewer.Domain;

/// <summary>
/// Initializes a new instance of the ProductResponse class
/// </summary>
public class ProductResponse
{
    public ProductResponse()
    {

    }

    public ProductResponse(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    [JsonProperty("images")] 
    public ImageResponse? Image { get; set; }

    public ProductPriceResponse? Prices { get; set; }
}