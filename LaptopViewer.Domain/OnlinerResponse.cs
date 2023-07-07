namespace LaptopViewer.Domain;

/// <summary>
/// Initializes a new instance of the OnlinerResponse class with an empty list of products
/// </summary>
public class OnlinerResponse
{
    public OnlinerResponse()
    {
        Products = new List<ProductResponse>();
    }

    public OnlinerResponse(ICollection<ProductResponse> products)
    {
        Products = products;
    }

    public ICollection<ProductResponse> Products { get; init; }
}
