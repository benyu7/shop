using System.Security.Cryptography;

namespace ShopDomain;

public class Price
{
    private int dollars;
    private int cents;
    
    public Price(decimal amount)
    {
        dollars = (int)amount;
        cents = (int)((amount - dollars) * 100);
    }

    public Price(int dollars, int cents)
    {
        this.dollars = dollars; 
        this.cents = cents;
    }

    public static Price operator +(Price a, Price b)
    {
        decimal amount = a.GetValue() + b.GetValue();
        return new Price(amount);
    }
    
    public decimal GetValue()
    {
        return dollars + (decimal)cents / 100;
    }
}