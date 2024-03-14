using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;

public interface IBiosBuilder
{
    public BiosBuilder WithName(Name name);

    public BiosBuilder WithBiosType(BiosType biosType);

    public BiosBuilder WithBiosVersion(BiosVersion biosVersion);

    public BiosBuilder WithSupportedCpus(ICollection<ICpu> supportedCpus);

    public Models.Bios Build();
}