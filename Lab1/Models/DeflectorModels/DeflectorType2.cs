using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.DeflectorModels;

public class DeflectorType2 : IDeflector
{
    private const int SecondClassDamageResistance = 10;
    private Hp _currentDamageResistance;

    public DeflectorType2()
    {
        _currentDamageResistance = new Hp(SecondClassDamageResistance);
    }

    public Damage ReceiveDamageAndReturnRemainingDamage(Damage amountOfDamage)
    {
        int remainingDamage = Math.Max(0, amountOfDamage.Amount - _currentDamageResistance.Amount);
        _currentDamageResistance = new Hp(Math.Max(0, _currentDamageResistance.Amount - amountOfDamage.Amount));
        return new Damage.NormalDamage(remainingDamage);
    }
}