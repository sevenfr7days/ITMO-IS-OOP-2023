using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.DifferentThings;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;

public interface IMotherboard : IComponent
{
    Socket Socket { get; }
    Quantity PciLinesQuantity { get; }
    Quantity SataPortsQuantity { get; }
    IChipset Chipset { get; }
    Version DdrStandard { get; }
    Quantity RamPortsQuantity { get; }
    FormFactor FormFactor { get; }
    IBios Bios { get; }
}