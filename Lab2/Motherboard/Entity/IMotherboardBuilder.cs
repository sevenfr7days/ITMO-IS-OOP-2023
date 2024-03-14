using Itmo.ObjectOrientedProgramming.Lab2.Bios.Entity;
using Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Motherboard.Entity;

public interface IMotherboardBuilder
{
    public MotherboardBuilder WithName(Name name);

    public MotherboardBuilder WithSocket(Socket socket);

    public MotherboardBuilder WithPciLinesQuantity(Quantity quantity);

    public MotherboardBuilder WithSataPortsQuantity(Quantity quantity);

    public MotherboardBuilder WithChipset(IChipset chipset);

    public MotherboardBuilder WithDdrStandard(Version standard);

    public MotherboardBuilder WithRamPortsQuantity(Quantity quantity);

    public MotherboardBuilder WithFormFactor(FormFactor formFactor);

    public MotherboardBuilder WithBios(IBios bios);

    public Models.Motherboard Build();
}