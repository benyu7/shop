namespace ShopDomain;

public record Quantity(int productId, int quantity) : DomainModel<int?>
{
    
}