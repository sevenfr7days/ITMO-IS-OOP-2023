using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;

public interface IDeflector
{
    Damage ReceiveDamageAndReturnRemainingDamage(Damage amountOfDamage);
}