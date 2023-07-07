namespace LaptopViewer.Domain;

/// <summary>
/// Represents a response containing image information
/// </summary>
public class ImageResponse
{
    public ImageResponse(string header, object icon)
    {
        Header = header;
        Icon = icon;
    }

    public string Header { get; set; }

    public object Icon { get; set; }

    public string Url => $"https:{Header}";
}
