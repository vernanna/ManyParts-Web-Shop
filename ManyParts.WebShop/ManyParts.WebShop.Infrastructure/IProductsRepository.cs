using ManyParts.WebShop.Domain;

namespace ManyParts.WebShop.Infrastructure;

public interface IProductsRepository
{
    IEnumerable<Product> GetProducts();

    Product GetProduct(Guid id);
}