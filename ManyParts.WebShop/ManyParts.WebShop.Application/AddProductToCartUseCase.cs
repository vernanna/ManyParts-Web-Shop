using ManyParts.WebShop.Domain;
using ManyParts.WebShop.Infrastructure;

namespace ManyParts.WebShop.Application;

public class AddProductToCartUseCase : IAddProductToCartUseCase
{
    private readonly ICartsRepository _cartsRepository;
    private readonly IProductsRepository _productsRepository;

    public AddProductToCartUseCase(ICartsRepository cartsRepository, IProductsRepository productsRepository)
    {
        _cartsRepository = cartsRepository;
        _productsRepository = productsRepository;
    }

    public void Execute(Guid productId, int amount)
    {
        var cart = _cartsRepository.GetCart();
        var product = _productsRepository.GetProduct(productId);

        cart.AddProduct(product, amount);

        _cartsRepository.Save();
    }
}
