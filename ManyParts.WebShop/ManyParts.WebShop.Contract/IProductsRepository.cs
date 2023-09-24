using ManyParts.WebShop.Domain;

namespace ManyParts.WebShop.Contract;

public interface IProductsRepository
{
    IEnumerable<Product> GetProducts();

    Product GetProduct(Guid id);
}