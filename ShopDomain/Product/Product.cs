namespace ShopDomain;

public record Product(int? Id, ProductCode Code, string Name, Price Price, string Description)
    : DomainModel<int?>(Id)
{
    public Product(ProductCode code) : this(code, "name", new Price(10), "description")
    {
    }

    public Product(ProductCode code, string name, Price price, string description) : this(null, code,
        name, price,
        description)
    {
    }
}