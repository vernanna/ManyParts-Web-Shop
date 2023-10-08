using ManyParts.WebShop.Contract;

namespace ManyParts.WebShop.Application;

public class DeleteProductFromCartUseCase : IDeleteProductFromCartUseCase
{
    private readonly ICartsRepository _cartsRepository;
    private readonly IProductsRepository _productsRepository;

    public DeleteProductFromCartUseCase(ICartsRepository cartsRepository, IProductsRepository productsRepository)
    {
        _cartsRepository = cartsRepository;
        _productsRepository = productsRepository;
    }

    public void Execute(Guid ID)
    {
            var cart = _cartsRepository.GetCart();
        var p = _productsRepository.GetProduct(ID);

        cart.Delete(p);

        _cartsRepository.Save();
    }
}
