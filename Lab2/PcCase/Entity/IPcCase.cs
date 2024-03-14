using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcCase.Entity;

public interface IPcCase : IComponent
{
    Millimeters MaxGpuLength { get; }
    Millimeters MaxGpuWidth { get; }
    Millimeters Length { get; }
    Millimeters Width { get; }
    Millimeters Height { get; }
    ICollection<FormFactor> SupportedMotherboardsFormFactors { get; }
}