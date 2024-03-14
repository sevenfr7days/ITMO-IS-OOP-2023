using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.PcCase.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.PcCase.Models;

public class PcCaseBuilder : IPcCaseBuilder
{
    private Name? _name;
    private Millimeters? _maxGpuLength;
    private Millimeters? _maxGpuWidth;
    private Millimeters? _length;
    private Millimeters? _width;
    private Millimeters? _height;
    private ICollection<FormFactor> _supportedMotherboardsFormFactors;

    public PcCaseBuilder(IPcCase innerPcCase)
    {
        _name = innerPcCase.Name;
        _maxGpuLength = innerPcCase.MaxGpuLength;
        _maxGpuWidth = innerPcCase.MaxGpuWidth;
        _supportedMotherboardsFormFactors = innerPcCase.SupportedMotherboardsFormFactors;
        _length = innerPcCase.Length;
        _width = innerPcCase.Width;
        _height = innerPcCase.Height;
    }

    public PcCaseBuilder()
    {
        _supportedMotherboardsFormFactors = new Collection<FormFactor>();
    }

    public PcCaseBuilder WithName(Name name)
    {
        _name = name;
        return this;
    }

    public PcCaseBuilder WithMaxGpuSizes(Millimeters maxGpuLength, Millimeters maxGpuWidth)
    {
        _maxGpuLength = maxGpuLength;
        _maxGpuWidth = maxGpuWidth;
        return this;
    }

    public PcCaseBuilder WithSupportedMotherboardsFactors(ICollection<FormFactor> supportedMotherboardsFormFactors)
    {
        _supportedMotherboardsFormFactors = supportedMotherboardsFormFactors;
        return this;
    }

    public PcCaseBuilder WithSizes(Millimeters length, Millimeters width, Millimeters height)
    {
        _length = length;
        _width = width;
        _height = height;
        return this;
    }

    public PcCase Build()
    {
        return new PcCase(
            _name,
            _maxGpuLength,
            _maxGpuWidth,
            _supportedMotherboardsFormFactors,
            _length,
            _width,
            _height);
    }
}