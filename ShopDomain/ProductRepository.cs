namespace ShopDomain;

public interface IProductRepository<T, K>
{
    IList<T> Read();
    IDictionary<Product, int> ReadWithQuantity();
    T ReadById(K id);
    T Create(T entity, int quantity);
    T Update(T entity, int quantity);
    T Delete(T entity);
}

public class MemoryProductRepository : IProductRepository<Product, int>
{
    private readonly IList<Product> _products = new List<Product>();
    private readonly IDictionary<ProductCode, int> _quantities = new Dictionary<ProductCode, int>();
    private int _id = 1;

    public IList<Product> Read()
    {
        return _products;
    }

    public IDictionary<Product, int> ReadWithQuantity()
    {
        var quantities = _products
            .Where(p => _quantities.ContainsKey(p.Code))
            .ToDictionary(p => p, p => _quantities[p.Code]);

        return quantities;
    }

    public Product ReadById(int id)
    {
        return _products.First(p => p.Id == id);
    }

    public Product Update(Product entity, int quantity = 0)
    {
        _products.Remove(_products.First(p => p.Id == entity.Id));
        _products.Add(entity);
        return entity;
    }

    public Product Delete(Product entity)
    {
        _products.Remove(_products.First(p => p.Id == entity.Id));
        return entity;
    }

    public Product Create(Product entity, int quantity = 0)
    {
        if (entity.Id is not null) throw new Exception("Create Entity with non null id");
        var savedEntity = entity with { Id = _id++ };
        _products.Add(savedEntity);
        _quantities.Add(entity.Code, quantity);
        return savedEntity;
    }
}