namespace ManyParts.WebShop.Domain;

public class Product
{
    private Product(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public static Product Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Product name must not be empty", nameof(name));
        }

        return new Product(Guid.NewGuid(), name);
    }
}