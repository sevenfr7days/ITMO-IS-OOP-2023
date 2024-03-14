using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Entity;

public interface ICoolingSystem : IComponent
{
    Millimeters SizeX { get; }
    Millimeters SizeY { get; }
    Millimeters SizeZ { get; }
    Watt MaxTdp { get; }
    ICollection<Socket> SupportedSockets { get; }
}