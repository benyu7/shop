using ShopDomain;

namespace UnitTest;

public class PriceTest
{
    [Fact]
    public void Test1()
    {
        var a = new Price(10, 10);
        var b = new Price(11, 0);
        var c = a + b;
        Assert.Equal(21.10m, c.GetValue());
    }

    [Fact]
    public void CartPriceTest()
    {
        var user = new User();
        var cart = new ShoppingCart(user);
        cart.AddToCart(new Product(new ProductCode("A"), "description", new Price(15.111m), ""));
        cart.AddToCart(new Product(new ProductCode("A"), "description", new Price(10.111m), ""));

        Assert.Equal(25.11m, cart.GetTotalPrice().GetValue());
    }
}