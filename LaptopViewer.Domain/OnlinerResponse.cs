namespace LaptopViewer.Domain;

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
