using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrengthClassBase;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.HullStrengthClassModels;
public class HullStrengthClass2 : IHullStrength
{
    private const int SecondClassDamageResistance = 10;
    private Hp _currentDamageResistance;

    public HullStrengthClass2(int shipMultiplier)
    {
        _currentDamageResistance = new Hp(SecondClassDamageResistance * shipMultiplier);
    }

    public Damage ReceiveDamage(Damage damage)
    {
        int remainingDamage = Math.Max(0, damage.Amount - _currentDamageResistance.Amount);
        _currentDamageResistance = new Hp(Math.Max(0, _currentDamageResistance.Amount - damage.Amount));
        return new Damage.NormalDamage(remainingDamage);
    }
}