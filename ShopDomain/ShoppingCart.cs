namespace ShopDomain;

public class ShoppingCart
{
    private List<Product> products = new();
    public void AddToCart(Product product)
    {
        products.Add(product);
    }

    public Price GetTotalPrice()
    {
        return products.Aggregate(new Price(0), (acc, p) => acc + p.GetPrice());
    }
}