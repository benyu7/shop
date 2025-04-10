namespace ShopDomain;

public record Order
{
    public List<Product> Products { get; init; }
    public User User { get; init; }
    public OrderStatus Status { get; init; }
    public PaymentOption PaymentOption { get; init; }

    public Order(ShoppingCart cart, PaymentOption paymentOption)
    {
        PaymentOption = paymentOption;
        User = cart.User;
        Products = cart.Products;
        Status = OrderStatus.Pending;
        
        bool paymentSuccessful = paymentOption.Pay(cart.GetTotalPrice());
    }

    public Order Complete()
    {
        return this with { Status = OrderStatus.Completed };
    }
}