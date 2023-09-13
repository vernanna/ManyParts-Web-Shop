using ManyParts.WebShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace ManyParts.WebShop.Infrastructure;

public class DatabaseContext : DbContext
{
    public DbSet<Product> Products { get; private set; } = null!;

    public DbSet<Cart> Carts { get; private set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("Data Source=ManyParts.WebShop.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().HasKey(product => product.Id);
        modelBuilder.Entity<Cart>().HasKey(cart => cart.Id);
        modelBuilder.Entity<CartItem>().HasKey(nameof(CartItem.ProductId), $"{nameof(Cart)}Id");
        
        modelBuilder.Entity<Product>().HasData(Product.Create("Gear"));
        modelBuilder.Entity<Product>().HasData(Product.Create("Piston"));
        modelBuilder.Entity<Product>().HasData(Product.Create("Engine"));
        modelBuilder.Entity<Product>().HasData(Product.Create("Cable"));
        modelBuilder.Entity<Cart>().HasData(Cart.Create());
    }
}