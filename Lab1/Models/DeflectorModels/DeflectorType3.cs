using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.DeflectorModels;
public class DeflectorType3 : IDeflector
{
    private const int ThirdClassDamageResistance = 40;
    private Hp _currentDamageResistance;
    public DeflectorType3()
    {
        _currentDamageResistance = new Hp(ThirdClassDamageResistance);
    }

    public Damage ReceiveDamageAndReturnRemainingDamage(Damage amountOfDamage)
    {
        int remainingDamage = Math.Max(0, amountOfDamage.Amount - _currentDamageResistance.Amount);
        _currentDamageResistance = new Hp(Math.Max(0, _currentDamageResistance.Amount - amountOfDamage.Amount));
        return new Damage.NormalDamage(remainingDamage);
    }
}