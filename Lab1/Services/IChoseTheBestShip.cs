using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ships;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ValueObject;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public interface IChoseTheBestShip
{
    public ExpeditionResult FindOptimalShip(ICollection<IShip> ships);
}