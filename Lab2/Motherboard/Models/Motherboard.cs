using System;
using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;
using Version = Itmo.ObjectOrientedProgramming.Lab2.ValueObjects.Version;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Models;

public class Motherboard : IMotherboard
{
    public Motherboard(
        Name? name,
        Socket? socket,
        Quantity? pciLinesQuantity,
        Quantity? sataPortsQuantity,
        IChipset? chipset,
        Version? ddrStandard,
        Quantity? ramPortsQuantity,
        FormFactor? formFactor,
        IBios? bios)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Socket = socket ?? throw new ArgumentNullException(nameof(socket));
        PciLinesQuantity = pciLinesQuantity ?? throw new ArgumentNullException(nameof(pciLinesQuantity));
        SataPortsQuantity = sataPortsQuantity ?? throw new ArgumentNullException(nameof(sataPortsQuantity));
        Chipset = chipset ?? throw new ArgumentNullException(nameof(chipset));
        DdrStandard = ddrStandard ?? throw new ArgumentNullException(nameof(ddrStandard));
        RamPortsQuantity = ramPortsQuantity ?? throw new ArgumentNullException(nameof(ramPortsQuantity));
        FormFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor));
        Bios = bios ?? throw new ArgumentNullException(nameof(bios));
    }

    public Socket Socket { get; }
    public Quantity PciLinesQuantity { get; }
    public Quantity SataPortsQuantity { get; }
    public IChipset Chipset { get; }
    public Version DdrStandard { get; }
    public Quantity RamPortsQuantity { get; }
    public FormFactor FormFactor { get; }
    public IBios Bios { get; }
    public Name Name { get; }
}