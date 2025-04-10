namespace ShopDomain;

public abstract class PaymentOption
{
    public string Name { get; }
    public abstract bool Pay(Price price);
    public abstract bool Mandatory { get; }

    public abstract void Print();
}

public class InternetBankingVisa : PaymentOption
{
    public override bool Mandatory => true;
    public override void Print()
    {
        throw new NotImplementedException();
    }

    public override bool Pay(Price price)
    {
        Console.WriteLine($"Paid {price} via Internet Banking Visa");
        return true;
    }
}

public class PayInStore : PaymentOption
{
    public override bool Pay(Price price)
    {
        Console.WriteLine("Payment deferred");
        return true;
    }

    public override bool Mandatory => false;
    public override void Print()
    {
        throw new NotImplementedException();
    }
}