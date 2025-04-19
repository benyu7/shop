using ShopDomain;

namespace UnitTest;

public class ProductTest
{
    [Fact]
    public void TestProduct()
    {
        var repository = new MemoryProductRepository();
        var productA = new Product(new ProductCode("A"), "name", new Price(10), "");
        var productB = new Product(new ProductCode("B"), "name", new Price(10), "");
        var productAId = repository.Create(productA);
        var productBId = repository.Create(productB);

        Assert.Equal(1, productAId.Id);
        Assert.Equal(2, productBId.Id);
    }
}