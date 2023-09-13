namespace ManyParts.WebShop.Domain;

public class Cart
{
    private readonly List<CartItem> _items = new();

    private Cart(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }

    public IReadOnlyCollection<CartItem> Items => _items;

    public static Cart Create() => new(Guid.NewGuid());

    public void AddProduct(Product product, int amount)
    {
        if (Items.Any(item => item.ProductId == product.Id))
        {
            var item = Items.Single(item => item.ProductId == product.Id);
            item.Add(amount);
        }
        else
        {
            var item = CartItem.Create(product);
            item.Add(amount);
            _items.Add(item);
        }
    }
}