namespace ShopDomain;

/**
 * Client Only
 */
public class ShoppingCart(User user)
{
    public User User { get; init; } = user;
    public List<Product> Products { get; init; } = new();

    public void AddToCart(Product product)
    {
        Products.Add(product);
    }

    public Price GetTotalPrice()
    {
        return Products.Aggregate(new Price(0), (acc, p) => acc + p.Price);
    }
}