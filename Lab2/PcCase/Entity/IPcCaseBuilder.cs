using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcCase.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcCase.Entity;

public interface IPcCaseBuilder
{
    public PcCaseBuilder WithName(Name name);

    public PcCaseBuilder WithMaxGpuSizes(Millimeters maxGpuLength, Millimeters maxGpuWidth);

    public PcCaseBuilder WithSupportedMotherboardsFactors(ICollection<FormFactor> supportedMotherboardsFormFactors);

    public PcCaseBuilder WithSizes(Millimeters length, Millimeters width, Millimeters height);

    public Models.PcCase Build();
}