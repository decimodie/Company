namespace Training.Api;

public static class DataTransferExtensions
{
    public static Product CreateProductRequestToProduct(this CreateProductRequest request)
        => Product.CreateNew(request.Descripcion, request.CodigoProducto, request.Precio);

    public static Product UpdateProductRequestToProduct(this ProductToUpdateRequest request)
        => Product.CreateNew(request.Descripcion, request.Descripcion, request.Precio);
}