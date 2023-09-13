using ManyParts.WebShop.Domain;

namespace ManyParts.WebShop.Infrastructure;

public interface ICartsRepository
{
    Cart GetCart();

    void Save();
}