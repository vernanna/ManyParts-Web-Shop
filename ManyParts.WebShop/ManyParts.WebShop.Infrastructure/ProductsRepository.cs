using ManyParts.WebShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace ManyParts.WebShop.Infrastructure;

public class ProductsRepository : IProductsRepository
{
    private readonly DatabaseContext _databaseContext;

    public ProductsRepository(DatabaseContext databaseContext) => _databaseContext = databaseContext;
    
    public IEnumerable<Product> GetProducts() =>
        _databaseContext.Products.FromSqlRaw("SELECT * FROM Products");

    public Product GetProduct(Guid id) =>
        _databaseContext.Products.FromSqlRaw($"SELECT * FROM Products")
            .Where(product => product.Id == id)
            .Single();
}