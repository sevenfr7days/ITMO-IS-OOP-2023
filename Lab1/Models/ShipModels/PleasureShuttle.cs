using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.HullStrengthClassBase;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.EngineModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.HullStrengthClassModels;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ShipModels;

public class PleasureShuttle : IShip
{
    private const int PleasureShuttleMultiplier = 1;
    private readonly IHullStrength _hullStrength;

    public PleasureShuttle()
    {
        JumperEngine = null;
        Deflector = null;
        ImpulseEngine = new ImpulseEngineCClass(PleasureShuttleMultiplier);
        _hullStrength = new HullStrengthClass1(PleasureShuttleMultiplier);
        ShipStatus = new ShipStatus.Active();
    }

    public ShipStatus ShipStatus { get; private set; }
    public IDeflector? Deflector { get; }
    public IJumperEngine? JumperEngine { get; }
    public IImpulseEngine ImpulseEngine { get; }

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