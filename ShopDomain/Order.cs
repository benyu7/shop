namespace ShopDomain;

public record Order
{
    public Order(ShoppingCart cart, PaymentOption paymentOption)
    {
        PaymentOption = paymentOption;
        User = cart.User;
        Products = cart.Products;
        Status = OrderStatus.Pending;

        var unused = paymentOption.Pay(cart.GetTotalPrice());
        paymentOption.Print();
    }

    public List<Product> Products { get; init; }
    public User User { get; init; }
    public OrderStatus Status { get; init; }
    public PaymentOption PaymentOption { get; init; }

    public Order Complete()
    {
        User.Bonus += new BonusPoint(10);
        return this with { Status = OrderStatus.Completed };
    }
}