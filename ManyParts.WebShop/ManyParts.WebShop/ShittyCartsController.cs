using ManyParts.WebShop.Application;
using ManyParts.WebShop.Domain;
using ManyParts.WebShop.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManyParts.WebShop;

[ApiController]
[Route("[controller]")]
public class ShittyCartsController : ControllerBase
{
    private readonly IGetCartUseCase _getCartUseCase;
    private readonly IAddProductToCartUseCase _addProductToCartUseCase;
    private readonly DatabaseContext _databaseContext;

    public ShittyCartsController(IGetCartUseCase getCartUseCase, IAddProductToCartUseCase addProductToCartUseCase)
    {
        _getCartUseCase = getCartUseCase;
        _addProductToCartUseCase = addProductToCartUseCase;
    }

    [HttpGet]
    public Cart Get() => _getCartUseCase.Execute();
    
    [HttpPut("products/{productId:guid}")]
    public void Add(Guid productId, int amount)
    {
        var cart = _databaseContext.Carts.FromSqlRaw("SELECT * FROM Carts").Include(cart => cart.Items).Single();
        var product = _databaseContext.Products.FromSqlRaw("SELECT * FROM Products").Single(product => product.Id == productId);
        
        if (cart.Items.Any(item => item.ProductId == product.Id))
        {
            var item = cart.Items.Single(item => item.ProductId == product.Id);
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive", nameof(amount));
            }

            item.Amount += amount;
        }
        else
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be positive", nameof(amount));
            }
            var item = new CartItem(product.Id, amount);
            cart.Items.Add(item);
        }
        
        _databaseContext.SaveChanges();
    }
}