using ManyParts.WebShop.Domain;

namespace ManyParts.WebShop.Application;

public interface IGetProductsUseCase
{
    IEnumerable<Product> Execute();
}