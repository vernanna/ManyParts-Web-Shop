using ManyParts.WebShop.Application;
using ManyParts.WebShop.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ManyParts.WebShop.Api;

[ApiController]
[Route("[controller]")]
public class CartsController : ControllerBase
{
    private readonly IGetCartUseCase _getCartUseCase;
    private readonly IAddProductToCartUseCase _addProductToCartUseCase;

    public CartsController(IGetCartUseCase getCartUseCase, IAddProductToCartUseCase addProductToCartUseCase)
    {
        _getCartUseCase = getCartUseCase;
        _addProductToCartUseCase = addProductToCartUseCase;
    }

    [HttpGet]
    public Cart Get() => _getCartUseCase.Execute();
    
    [HttpPut("products/{productId:guid}")]
    public void Add(Guid productId, int amount) => _addProductToCartUseCase.Execute(productId, amount);
}