using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Cpu.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Bios.Models;

public class BiosBuilder : IBiosBuilder
{
    private Name? _name;
    private BiosType? _biosType;
    private BiosVersion? _biosVersion;
    private ICollection<ICpu>? _supportedCpus;

    public BiosBuilder(IBios innerBios)
    {
        _name = new Name(innerBios.Name.Forename);
        _biosType = new BiosType(innerBios.BiosType.BiosTypeName);
        _biosVersion = new BiosVersion(innerBios.BiosVersion.Version);
        _supportedCpus = new List<ICpu>(innerBios.SupportedCpus);
    }

    public BiosBuilder()
    {
        _supportedCpus = new Collection<ICpu>();
    }

    public BiosBuilder WithName(Name name)
    {
        _name = name;
        return this;
    }

    public BiosBuilder WithBiosType(BiosType biosType)
    {
        _biosType = biosType;
        return this;
    }

    public BiosBuilder WithBiosVersion(BiosVersion biosVersion)
    {
        _biosVersion = biosVersion;
        return this;
    }

    public BiosBuilder WithSupportedCpus(ICollection<ICpu> supportedCpus)
    {
        _supportedCpus = supportedCpus;
        return this;
    }

    public Bios Build()
    {
        return new Bios(
            _name,
            _biosType,
            _biosVersion,
            _supportedCpus);
    }
}