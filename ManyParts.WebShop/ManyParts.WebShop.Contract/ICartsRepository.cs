using ManyParts.WebShop.Domain;

namespace ManyParts.WebShop.Contract;

public interface ICartsRepository
{
    Cart GetCart();

    void Save();
}