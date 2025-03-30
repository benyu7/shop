namespace ShopDomain;

public class Product
{
    private string name;
    private string description;
    private Price price;

    public Product(string name, string description, Price price)
    {
        this.name = name;
        this.description = description;
        this.price = price;
    }

    public Price GetPrice()
    {
        return price;
    }
}