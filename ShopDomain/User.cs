namespace ShopDomain;

public record User
{
    public BonusPoint Bonus { get; set; } = new(0);
    public string Email { get; init; }
    public string Name { get; init; }
}