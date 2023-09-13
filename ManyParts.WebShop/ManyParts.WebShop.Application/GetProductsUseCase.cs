using ManyParts.WebShop.Domain;
using ManyParts.WebShop.Infrastructure;

namespace ManyParts.WebShop.Application;

public class GetProductsUseCase : IGetProductsUseCase
{
    private readonly IProductsRepository _productsRepository;

    public GetProductsUseCase(IProductsRepository productsRepository) => _productsRepository = productsRepository;

    public IEnumerable<Product> Execute() => _productsRepository.GetProducts();
}
