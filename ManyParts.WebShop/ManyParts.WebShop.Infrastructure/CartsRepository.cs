using ManyParts.WebShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace ManyParts.WebShop.Infrastructure;

public class CartsRepository : ICartsRepository
{
    private readonly DatabaseContext _databaseContext;

    public CartsRepository(DatabaseContext databaseContext) => _databaseContext = databaseContext;

    public Cart GetCart() =>
        _databaseContext.Carts.FromSqlRaw("SELECT * FROM Carts").Include(cart => cart.Items).Single();

    public void Save() => _databaseContext.SaveChanges();
}