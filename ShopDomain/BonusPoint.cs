namespace ShopDomain;

public class BonusPoint
{
    private int _value;

    public BonusPoint(int value)
    {
        _value = value;
    }

    public static BonusPoint operator+(BonusPoint p1, BonusPoint p2)
    {
        int value = p1.GetValue() + p2.GetValue();
        BonusPoint result = new BonusPoint(value);
        return result;
    }

    public int GetValue()
    {
        return _value;
    }
}