namespace ManyParts.WebShop.Domain;

public class CartItem
{
    private CartItem(Guid productId, int amount)
    {
        ProductId = productId;
        Amount = amount;
    }

    public Guid ProductId { get; private set; }
    
    public int Amount { get; private set; }

    internal void Add(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be positive", nameof(amount));
        }

        Amount += amount;
    }

    internal static CartItem Create(Product product) => new(product.Id, 0);
}