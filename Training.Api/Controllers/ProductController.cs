using System;

namespace Training.Api;

[ApiController]
[Route("api/productos")]
public class ProductsController(IProductServices ProductServices) : ControllerBase
{
    private readonly IProductServices productServices = ProductServices;

    [HttpGet]
    public IAsyncEnumerable<FetchProductInfo> GetAll()
    {
        return productServices.FetchProductInfoAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest model)
    {
        Product productToCreate = model.CreateProductRequestToProduct();
        await productServices.CreateProductAsync(productToCreate);
        return Ok(new { message = "User created" });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(ProductToUpdateRequest model)
    {
        Product productToUpdate = model.UpdateProductRequestToProduct();
        await productServices.UpdateProductAsync(productToUpdate);
        return Ok(new { message = "User updated" });
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(DeleteProductRequest request)
    {
        await productServices.DeleteProductAsync(request.Id);
        return Ok(new { message = "User deleted" });
    }

    [HttpGet("{mes}")]
    public IAsyncEnumerable<FetchProductInfo> GetProductsByMonthDiscount(DateTime mes)
    {
        return productServices.FetchProductsByMonthAsync(mes);
    }
}