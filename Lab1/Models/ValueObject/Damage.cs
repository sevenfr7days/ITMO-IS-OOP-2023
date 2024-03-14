namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

public abstract record Damage
{
    private Damage(int amount)
    {
        Amount = amount;
    }

    public int Amount { get; }

    public sealed record PhotonDamage(int Amount) : Damage(Amount);
    public sealed record NormalDamage(int Amount) : Damage(Amount);
}