namespace ShopDomain;

public readonly record struct BonusPoint(int Value)
{
    public static BonusPoint operator +(BonusPoint p1, BonusPoint p2)
    {
        var value = p1.GetValue() + p2.GetValue();
        return new BonusPoint(value);
    }

    public int GetValue()
    {
        return Value;
    }
}