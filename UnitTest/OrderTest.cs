using Moq;
using ShopDomain;

namespace UnitTest;

public class OrderTest
{
    [Fact]
    public void CreateOrder()
    {
        var shop = new Shop();
        shop.AddProduct(new Product(new ProductCode("A"), "A", new Price(15), ""), 1);
        shop.AddProduct(new Product(new ProductCode("B"), "B", new Price(10), ""), 1);

        var user = new User();
        var cart = new ShoppingCart(user);
        cart.AddToCart(shop.BuyProduct());
        cart.AddToCart(new Product("", "", new Price(10m)));

        var paymentOptionMock = new Mock<PaymentOption>();

        var order = new Order(cart, paymentOptionMock.Object);

        Assert.NotNull(order);
        paymentOptionMock.Verify(x => x.Pay(new Price(25.11m)), Times.Once);
    }

    [Fact]
    public void CompleteOrder()
    {
        var user = new User();
        var cart = new ShoppingCart(user);
        // cart.AddToCart(new Product("", "", new Price(25)));
        // cart.AddToCart(new Product("", "", new Price(10)));

        var paymentOptionMock = new Mock<PaymentOption>();
        var order = new Order(cart, paymentOptionMock.Object);
        order.Complete();

        Assert.Equal(new BonusPoint(10), user.Bonus);
    }
}