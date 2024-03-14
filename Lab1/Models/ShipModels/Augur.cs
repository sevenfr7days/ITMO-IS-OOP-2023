using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrengthClassBase;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.DeflectorModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.EngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullStrengthClassModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ShipModels;

public class Augur : IShip
{
    private const int AugurMultiplier = 3;
    private readonly IHullStrength _hullStrength;

    public Augur(bool havePhotonDeflector)
    {
        Deflector = havePhotonDeflector ? new PhotonDeflectorDecorator(new DeflectorType3()) : new DeflectorType3();
        _hullStrength = new HullStrengthClass3(AugurMultiplier);
        ImpulseEngine = new ImpulseEngineEClass(AugurMultiplier);
        JumperEngine = new JumperEngineAClass();
        ShipStatus = new ShipStatus.Active();
    }

    public IDeflector? Deflector { get; }
    public IJumperEngine JumperEngine { get; }
    public IImpulseEngine ImpulseEngine { get; }
    public ShipStatus ShipStatus { get; private set; }

    public void ChangeShipStatus(ShipStatus shipStatus)
    {
        ShipStatus = shipStatus;
    }

    public ShipStatus ReceiveDamage(IObstacle obstacle)
    {
        Damage remainingDamage;
        Damage.PhotonDamage remainingPhotonDamage;

        if (obstacle.Damage is Damage.PhotonDamage photonDamage)
        {
            remainingDamage = new Damage.NormalDamage(0);
            remainingPhotonDamage = new Damage.PhotonDamage(photonDamage.Amount);
        }
        else
        {
            remainingDamage = new Damage.NormalDamage(obstacle.Damage.Amount);
            remainingPhotonDamage = new Damage.PhotonDamage(0);
        }

        if (Deflector is PhotonDeflectorDecorator photonDeflector)
        {
            remainingDamage = photonDeflector.ReceiveDamageAndReturnRemainingDamage(remainingDamage);
            remainingPhotonDamage =
                photonDeflector.ReceivePhotonDamageAndReturnRemainingPhotonDamage(remainingPhotonDamage);
        }

        remainingDamage = _hullStrength.ReceiveDamage(remainingDamage);

        if (remainingPhotonDamage.Amount > 0)
        {
            return new ShipStatus.CrewDead();
        }

        if (remainingDamage.Amount > 0)
        {
            return new ShipStatus.ShipBrokenDown();
        }

        return new ShipStatus.Active();
    }
}