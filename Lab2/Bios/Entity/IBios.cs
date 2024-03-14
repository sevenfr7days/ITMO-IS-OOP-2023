using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;

public interface IBios : IComponent
{
    BiosType BiosType { get; }
    BiosVersion BiosVersion { get; }
    ICollection<ICpu> SupportedCpus { get; }
}