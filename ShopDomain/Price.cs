namespace ShopDomain;

public readonly record struct Price(int Dollars, int Cents)
{
    public Price(decimal amount)
        : this((int)amount, (int)((amount - (int)amount) * 100)) { }

    public decimal GetValue() => Dollars + (decimal)Cents / 100;

    public static Price operator +(Price a, Price b)
    {
        var totalCents = a.Cents + b.Cents;
        var extraDollars = totalCents / 100;
        var cents = totalCents % 100;
        var dollars = a.Dollars + b.Dollars + extraDollars;

        return new Price(dollars, cents);
    }
}