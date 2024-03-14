using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;

public class Bios : IBios
{
    public Bios(Name? name, BiosType? biosType, BiosVersion? biosVersion, ICollection<ICpu>? supportedCpus)
    {
        BiosType = biosType ?? throw new ArgumentNullException(nameof(biosType));
        BiosVersion = biosVersion ?? throw new ArgumentNullException(nameof(biosVersion));
        SupportedCpus = supportedCpus ?? throw new ArgumentNullException(nameof(supportedCpus));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public BiosType BiosType { get; private set; }
    public BiosVersion BiosVersion { get; private set; }
    public ICollection<ICpu> SupportedCpus { get; private set; }
    public Name Name { get; private set; }
}