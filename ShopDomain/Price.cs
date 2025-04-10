namespace ShopDomain;

public class Price
{
    private readonly int _dollars;
    private readonly int _cents;
    
    public Price(decimal amount)
    {
        _dollars = (int)amount;
        _cents = (int)((amount - _dollars) * 100);
    }

    public Price(int dollars, int cents)
    {
        _dollars = dollars; 
        _cents = cents;
    }

    public static Price operator +(Price a, Price b)
    {
        decimal amount = a.GetValue() + b.GetValue();
        return new Price(amount);
    }
    
    public decimal GetValue()
    {
        return _dollars + (decimal)_cents / 100;
    }
}