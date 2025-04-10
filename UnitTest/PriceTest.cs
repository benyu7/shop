using Moq;
using ShopDomain;
using Xunit.Abstractions;

namespace UnitTest;

public class PriceTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public PriceTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        Price a = new Price(10, 10);
        Price b = new Price(11, 0);
        Price c = a + b;
        Assert.Equal(21.10m, c.GetValue());
    }

    [Fact]
    public void CartPriceTest()
    {
        User user = new User();
        ShoppingCart cart = new ShoppingCart(user);
        cart.AddToCart(new Product("a", "description", new Price(15.111m)));
        cart.AddToCart(new Product("a", "description", new Price(10m)));
        
        Assert.Equal(25.11m, cart.GetTotalPrice().GetValue());
    }
    
    [Fact]
     public void CreateOrder()
     {
         User user = new User();
         ShoppingCart cart = new ShoppingCart(user);
         cart.AddToCart(new Product("a", "description", new Price(15.111m)));
         cart.AddToCart(new Product("b", "description", new Price(10m)));

         var paymentOption = new Mock<PaymentOption>();
         // paymentOption.Setup(x => x.Pay(cart.GetTotalPrice())).Returns(true);

         Order order = new Order(cart, paymentOption.Object);
         
         Assert.NotNull(order);
         paymentOption.Verify(x => x.Pay(new Price(0)), Times.Once);
     }
}