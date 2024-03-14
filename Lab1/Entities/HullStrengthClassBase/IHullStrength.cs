using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrengthClassBase;

public interface IHullStrength
{
    public Damage ReceiveDamage(Damage damage);
}