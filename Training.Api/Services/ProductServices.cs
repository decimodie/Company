namespace Training.Api;

public class ProductServices(IStore store) : IProductServices
{
    private readonly IStore<Product> ProductStore = store.GetStore<Product>();

    public async ValueTask CreateProductAsync(Product ProductToCreate)
    {
        await ProductStore.CreateProductAsync(ProductToCreate);
    }

    public async ValueTask DeleteProductAsync(int deleteProductRequest)
    {
        await ProductStore.DeleteProductAsync(deleteProductRequest);
    }

    public IAsyncEnumerable<FetchProductInfo> FetchProductInfoAsync()
    {
        return ProductStore.FetchProductInfoAsync();
    }

    public async ValueTask UpdateProductAsync(Product productUpdateRequest)
    {
        await ProductStore.UpdateProductAsync(productUpdateRequest);
    }

    public IAsyncEnumerable<FetchProductInfo> FetchProductsByMonthAsync(DateTime month)
    {
        return ProductStore.FetchProductInfoByMonthAsync(month);
    }
}
