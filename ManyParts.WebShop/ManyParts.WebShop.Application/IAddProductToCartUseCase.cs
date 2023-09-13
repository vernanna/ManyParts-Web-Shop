namespace ManyParts.WebShop.Application;

public interface IAddProductToCartUseCase
{
    void Execute(Guid productId, int amount);
}