using ManyParts.WebShop.Contract;
using ManyParts.WebShop.Domain;

namespace ManyParts.WebShop.Application;

public class GetCartUseCase : IGetCartUseCase
{
    private readonly ICartsRepository _cartsRepository;

    public GetCartUseCase(ICartsRepository cartsRepository) => _cartsRepository = cartsRepository;

    public Cart Execute() => _cartsRepository.GetCart();
}
