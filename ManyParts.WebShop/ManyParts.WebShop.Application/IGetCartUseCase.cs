using ManyParts.WebShop.Domain;

namespace ManyParts.WebShop.Application;

public interface IGetCartUseCase
{
    Cart Execute();
}