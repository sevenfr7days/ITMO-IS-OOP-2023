using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ObstacleModels;

public class Asteroid : INormalSpaceObstacle
{
    private const int AsteroidDamage = 1;

    public Asteroid()
    {
        Damage = new Damage.NormalDamage(AsteroidDamage);
    }

    public Damage Damage { get; }
}