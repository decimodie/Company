namespace Training.Api;

public class FetchProductInfo
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = string.Empty;

    public string CodigoProducto { get; set; } = string.Empty;

    public decimal Precio { get; set; }
}
