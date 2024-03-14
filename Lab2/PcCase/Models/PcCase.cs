using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.PcCase.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcCase.Models;

public class PcCase : IPcCase
{
    public PcCase(
        Name? name,
        Millimeters? maxGpuLength,
        Millimeters? maxGpuWidth,
        ICollection<FormFactor>? supportedMotherboardsFormFactors,
        Millimeters? length,
        Millimeters? width,
        Millimeters? height)
    {
        MaxGpuLength = maxGpuLength ?? throw new ArgumentNullException(nameof(maxGpuLength));
        MaxGpuWidth = maxGpuWidth ?? throw new ArgumentNullException(nameof(maxGpuWidth));
        SupportedMotherboardsFormFactors = supportedMotherboardsFormFactors ?? throw new ArgumentNullException(nameof(supportedMotherboardsFormFactors));
        Length = length ?? throw new ArgumentNullException(nameof(length));
        Width = width ?? throw new ArgumentNullException(nameof(width));
        Height = height ?? throw new ArgumentNullException(nameof(height));
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public Millimeters MaxGpuLength { get; }
    public Millimeters MaxGpuWidth { get; }
    public Millimeters Length { get; }
    public Millimeters Width { get; }
    public Millimeters Height { get; }
    public ICollection<FormFactor> SupportedMotherboardsFormFactors { get; }
    public Name Name { get; }
}