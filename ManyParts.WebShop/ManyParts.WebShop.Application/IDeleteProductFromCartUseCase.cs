namespace ManyParts.WebShop.Application;

public interface IDeleteProductFromCartUseCase
{
    void Execute(Guid ID);
}