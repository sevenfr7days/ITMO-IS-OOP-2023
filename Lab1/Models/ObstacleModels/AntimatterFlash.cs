using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ObstacleModels;

public class AntimatterFlash : IDenseSpaceNebulaObstacle
{
    private const int AntimatterFlashPhotonDamage = 1;

    public AntimatterFlash()
    {
        Damage = new Damage.PhotonDamage(AntimatterFlashPhotonDamage);
    }

    public Damage Damage { get; }
}