using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.ObstacleModels;

public class Meteor : INormalSpaceObstacle
{
    private const int MeteorDamage = 4;

    public Meteor()
    {
        Damage = new Damage.NormalDamage(MeteorDamage);
    }

    public Damage Damage { get; }
}