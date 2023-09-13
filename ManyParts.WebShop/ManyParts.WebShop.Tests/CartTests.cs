using FluentAssertions;
using ManyParts.WebShop.Domain;

namespace ManyParts.WebShop.Tests;

public class CartTests
{
    [Fact]
    public void AddsAnItem()
    {
        // Given
        var cart = Cart.Create();
        var product = Product.Create("Piston");
        
        // When
        cart.AddProduct(product, 1);
        
        // Then
        cart.Items.Should().HaveCount(1);
        cart.Items.Single().ProductId.Should().Be(product.Id);
        cart.Items.Single().Amount.Should().Be(1);
    }
}