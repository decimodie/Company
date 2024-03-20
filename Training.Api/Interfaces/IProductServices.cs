namespace Training.Api;

public interface IProductServices
{
    ValueTask CreateProductAsync(Product ProductToCreate);
    
    IAsyncEnumerable<FetchProductInfo> FetchProductInfoAsync();

    ValueTask UpdateProductAsync(Product productUpdateRequest);

    ValueTask DeleteProductAsync(int deleteProductRequest);
    
    IAsyncEnumerable<FetchProductInfo> FetchProductsByMonthAsync(DateTime month);
}
