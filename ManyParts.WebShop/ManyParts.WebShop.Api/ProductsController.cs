using ManyParts.WebShop.Application;
using ManyParts.WebShop.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ManyParts.WebShop.Api;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IGetProductsUseCase _getProductsUseCase;

    public ProductsController(IGetProductsUseCase getProductsUseCase) => _getProductsUseCase = getProductsUseCase;

    [HttpGet]
    public IEnumerable<Product> Get() => _getProductsUseCase.Execute();
}