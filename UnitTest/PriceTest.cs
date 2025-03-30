using ShopDomain;

namespace UnitTest;

public class PriceTest
{
    [Fact]
    public void Test1()
    {
        Price a = new Price(10, 10);
        Price b = new Price(11, 0);
        Price c = a + b;
        Assert.Equal(21.10m, c.GetValue());
    }

    [Fact]
    public void Test2()
    {
        ShoppingCart cart = new ShoppingCart();
        cart.AddToCart(new Product("a", "description", new Price(15.111m)));
        cart.AddToCart(new Product("a", "description", new Price(10m)));
        
        Assert.Equal(25.11m, cart.GetTotalPrice().GetValue());
    }
}