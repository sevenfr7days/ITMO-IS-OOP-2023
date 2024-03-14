using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Cpu.Models;

public class Cpu : ICpu
{
    public Cpu(
        Name? name,
        Gigahertz? coreFrequency,
        Quantity? coresQuantity,
        Socket? socket,
        bool? isVideoCoreIntegrated,
        ICollection<Megahertz>? supportedMemoryFrequencies,
        Watt? tdp,
        Watt? powerConsumption)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        CoreFrequency = coreFrequency ?? throw new ArgumentNullException(nameof(coreFrequency));
        CoresQuantity = coresQuantity ?? throw new ArgumentNullException(nameof(coresQuantity));
        Socket = socket ?? throw new ArgumentNullException(nameof(socket));
        IsVideoCoreIntegrated = isVideoCoreIntegrated ?? throw new ArgumentNullException(nameof(isVideoCoreIntegrated));
        SupportedMemoryFrequencies = supportedMemoryFrequencies ?? throw new ArgumentNullException(nameof(supportedMemoryFrequencies));
        Tdp = tdp ?? throw new ArgumentNullException(nameof(tdp));
        PowerConsumption = powerConsumption ?? throw new ArgumentNullException(nameof(powerConsumption));
    }

    public Gigahertz CoreFrequency { get; }
    public Quantity CoresQuantity { get; }
    public Socket Socket { get; }
    public bool IsVideoCoreIntegrated { get; }
    public Watt Tdp { get; }
    public Watt PowerConsumption { get; }
    public Name Name { get; }
    public ICollection<Megahertz> SupportedMemoryFrequencies { get; }
}