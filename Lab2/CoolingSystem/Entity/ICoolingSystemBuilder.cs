using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.CoolingSystem.Entity;

public interface ICoolingSystemBuilder
{
    public CoolingSystemBuilder WithName(Name name);

    public CoolingSystemBuilder WithSize(Millimeters x, Millimeters y, Millimeters z);

    public CoolingSystemBuilder WithMaxTdp(Watt maxTdp);

    public CoolingSystemBuilder WithSupportedSockets(ICollection<Socket> sockets);

    public Models.CoolingSystem Build();
}