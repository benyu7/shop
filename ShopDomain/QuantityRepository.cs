namespace ShopDomain;

public interface IQuantityRepository<T, K>
{
    IList<T> Read();
    T ReadById(K id);
    T Create(T entity);
    T Update(T entity);
    T Delete(T entity);
}

public class MemoryQuantityRepository : IQuantityRepository<Quantity, int>
{
    private List<Quantity> _quantities;
    public IList<Quantity> Read()
    {
        return _quantities;
    }

    public Quantity ReadById(int id)
    {
        return _quantities.First(q => q.Id == id);
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