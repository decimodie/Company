namespace Training.Api;

public static class CompanyStore
{
    public static async ValueTask CreateProductAsync(this IStore<Product> Store, Product ProductToCreate)
    {
        await Store.ExecuteStoredProcedureAsync("[dbo].[InsertProduct]",
            new
            {
                ProductToCreate.Descripcion,
                ProductToCreate.CodigoProducto,
                ProductToCreate.Precio
            });
    }

    public static IAsyncEnumerable<FetchProductInfo> FetchProductInfoAsync(this IStore<Product> Store)
    {
        return Store.ExecuteStoredProcedureQueryAsync<FetchProductInfo>("[dbo].[FetchProducts]");
    }

    public static async ValueTask UpdateProductAsync(this IStore<Product> Store, Product productUpdateRequest)
    {
        await Store.ExecuteStoredProcedureAsync("[dbo].[DeleteProduct]",
        new
        {
            productUpdateRequest.Id,
            productUpdateRequest.Descripcion,
            productUpdateRequest.CodigoProducto,
            productUpdateRequest.Precio
        });
    }

    public static async ValueTask DeleteProductAsync(this IStore<Product> Store, int Id)
    {
        await Store.ExecuteStoredProcedureAsync("[dbo].[DeleteProduct]", new { Id });
    }

    public static IAsyncEnumerable<FetchProductInfo> FetchProductInfoByMonthAsync(this IStore<Product> Store, DateTime mes)
    {
        return Store.ExecuteStoredProcedureQueryAsync<FetchProductInfo>("[dbo].[FetchProductsByMonth]", new { mes });
    }
}
