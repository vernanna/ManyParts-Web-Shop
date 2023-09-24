using ManyParts.WebShop.Contract;
using ManyParts.WebShop.Domain;

namespace ManyParts.WebShop.Application;

public class GetProductsUseCase : IGetProductsUseCase
{
    private readonly IProductsRepository _productsRepository;

    public GetProductsUseCase(IProductsRepository productsRepository) => _productsRepository = productsRepository;

    public IEnumerable<Product> Execute() => _productsRepository.GetProducts();
}
