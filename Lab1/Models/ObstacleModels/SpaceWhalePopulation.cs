using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ObstacleModels;

public class SpaceWhalePopulation : INitrogenParticleNebulaObstacle
{
    private const int SpaceWhaleDamage = 40;

    public SpaceWhalePopulation(int amountOfWhales)
    {
        Damage = new Damage.NormalDamage(SpaceWhaleDamage * amountOfWhales);
    }

    public Damage Damage { get; }
}