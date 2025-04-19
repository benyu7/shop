using ShopDomain.Exceptions;

namespace ShopDomain;

/**
 * Singleton
 * This class handles all shop related functionality
 */
public class Shop
{
    private Dictionary<Product, int> _products;

    public Shop(IProductRepository<Product, int?> productRepository)
    {
        _products = productRepository.Read();
    }

    public void AddProduct(Product product, int quantity)
    {
        products.Add(product, quantity);
    }

    public Product BuyProduct(ProductCode code, int quantity)
    {
        var exists = products.Any(p => p.Key.Code == code);
        if (!exists) throw new Exception("Product not found");

        var product = products.First(p => p.Key.Code == code)!.Key;
        var stock = products.GetValueOrDefault(product, 0);
        if (stock < quantity) throw new OutOfStockException();
        products[product] -= quantity;
        return product;
    }
}