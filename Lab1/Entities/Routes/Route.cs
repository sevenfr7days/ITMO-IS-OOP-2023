using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceEnvironment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Routes;

public class Route
{
    public Route(
        IReadOnlyCollection<ISpaceEnvironment> spaceEnvironmentCollection)
    {
        EnvironmentsCollection = spaceEnvironmentCollection;
    }

    public IReadOnlyCollection<ISpaceEnvironment> EnvironmentsCollection { get; }
}