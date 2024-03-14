using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.DeflectorModels;

public class PhotonDeflectorDecorator : IDeflector
{
    private readonly IDeflector _innerDeflector;
    private int _currentPhotonDamageResistance;

    public PhotonDeflectorDecorator(IDeflector innerDeflector)
    {
        _currentPhotonDamageResistance = 3;
        _innerDeflector = innerDeflector;
    }

    public Damage ReceiveDamageAndReturnRemainingDamage(Damage amountOfDamage)
    {
        Damage remainingDamage = _innerDeflector.ReceiveDamageAndReturnRemainingDamage(amountOfDamage);
        return remainingDamage;
    }

    public Damage.PhotonDamage ReceivePhotonDamageAndReturnRemainingPhotonDamage(Damage.PhotonDamage photonDamage)
    {
        var remainingPhotonDamage =
            new Damage.PhotonDamage(photonDamage.Amount - _currentPhotonDamageResistance);
        _currentPhotonDamageResistance -= photonDamage.Amount;
        return remainingPhotonDamage;
    }
}